using BusinessLayer.Models.DTO;
using DataLayer.Models.Domain;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using System.Net.Http;
using System.Text;

namespace BusinessLayer.Services.CommonServices
{
    public class CommonServiceMidjourney
    {
        private readonly string _url;
        private readonly string _token;
        private readonly HttpClient _httpClient;

        public CommonServiceMidjourney(IConfiguration configuration)
        {
            _url = configuration["Midjourney:Url"];
            _token = configuration["Midjourney:Token"];
            _httpClient = new HttpClient();
        }

        public async Task<MidjourneyResponseDto> SendDrinkImageGenerationRequest(Style styleDrink)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

            var mainObject = $"Product photography of a {styleDrink.Color.Prompt}-cocktail";
            var describeMainObject = $", liquids opacity is {styleDrink.Transparency.Prompt} {styleDrink.Color.Prompt}, garnished with {styleDrink.Garnish.Prompt}";
            var eviroment = ", soft focus colourful modern kitchen background, standing on a white marble table with decorations around";
            var settings = ", high resolution photography, hyper-detailed, professional color grading, white light, 35mm lens, f1.8, 8k --v 5";

            var obj = new MidjourneyCreateDto();
            obj.cmd = "imagine";
            obj.msg = $"{mainObject}{describeMainObject}{eviroment}{settings}";

            var payload = JsonConvert.SerializeObject(obj);
            var data = new StringContent(payload, Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync(_url, data);

            MidjourneyResponseDto response = new MidjourneyResponseDto();
            try
            {
                response = JsonConvert.DeserializeObject<MidjourneyResponseDto>(await result.Content.ReadAsStringAsync());
            }
            catch (Exception) { throw new HttpRequestException("TNL API Down again"); }
            return response;
        }

        public async Task<MidjourneyResponseDto> SendUpscaleRequest(MidjourneyUpscaleDto obj)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", _token);

            var payload = JsonConvert.SerializeObject(obj);
            var data = new StringContent(payload, Encoding.UTF8, "application/json");
            var result = await _httpClient.PostAsync(_url, data);

            MidjourneyResponseDto response = new MidjourneyResponseDto();
            try
            {
                response = JsonConvert.DeserializeObject<MidjourneyResponseDto>(await result.Content.ReadAsStringAsync());
            }
            catch (Exception) { throw new HttpRequestException("TNL API Down again"); }
            return response;
        }
    }
}