using DataLayer.Models.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace BusinessLayer.Services.CommonServices;

public class CommonServiceToken
{
    private readonly HttpContext _httpContext;

    private readonly string _signingSecret;

    public CommonServiceToken(IConfiguration configuration, IHttpContextAccessor httpContextAcessor)
    {
        _httpContext = httpContextAcessor.HttpContext;
        _signingSecret = configuration["Jwt:SigningSecret"];
    }

    public string GetTokenOwnerId() => GetSecurityToken().Claims.First(o => o.Type == "nameid").Value;

    public string GenerateToken(ApplicationUser applicationUser)
    {
        var signingKey = Convert.FromBase64String(_signingSecret);

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.NameIdentifier, applicationUser.Id),
        };

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            SigningCredentials = new SigningCredentials(
                new SymmetricSecurityKey(signingKey),
                SecurityAlgorithms.HmacSha256Signature),
            Expires = DateTime.UtcNow.AddHours(24),

            Subject = new ClaimsIdentity(claims)
        };

        var jwtTokenHandler = new JwtSecurityTokenHandler();

        var jwtSecurityToken = jwtTokenHandler.CreateJwtSecurityToken(tokenDescriptor);

        return jwtTokenHandler.WriteToken(jwtSecurityToken);
    }

    private JwtSecurityToken GetSecurityToken()
    {
        var token = _httpContext.Request.Headers.FirstOrDefault(o => o.Key == "Authorization").Value.ToString().Remove(0, 7);
        var handler = new JwtSecurityTokenHandler();
        return handler.ReadJwtToken(token);
    }
}