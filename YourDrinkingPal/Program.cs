using BusinessLayer;
using BusinessLayer.Data;
using BusinessLayer.Services;
using BusinessLayer.Services.CommonServices;
using DataLayer;
using DataLayer.Data;
using DataLayer.Models.Domain;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace ApplicationLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            builder.Services.AddSession(options => { options.Cookie.IsEssential = true; });

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(typeof(DtoMappings));

            #region Injections

            //INJECTION REPOSITORY
            builder.Services.AddScoped<IRepositoryColor, RepositoryColor>();
            builder.Services.AddScoped<IRepositoryDrink, RepositoryDrink>();
            builder.Services.AddScoped<IRepositoryFlavour, RepositoryFlavour>();
            builder.Services.AddScoped<IRepositoryGarnish, RepositoryGarnish>();
            builder.Services.AddScoped<IRepositoryGlass, RepositoryGlass>();
            builder.Services.AddScoped<IRepositoryUploadedImage, RepositoryUploadedImage>();
            builder.Services.AddScoped<IRepositoryIngridient, RepositoryIngridient>();
            builder.Services.AddScoped<IRepositoryInstruction, RepositoryInstruction>();
            builder.Services.AddScoped<IRepositoryMeasurement, RepositoryMeasurement>();
            builder.Services.AddScoped<IRepositoryRecipe, RepositoryRecipe>();
            builder.Services.AddScoped<IRepositoryStyle, RepositoryStyle>();
            builder.Services.AddScoped<IRepositoryTag, RepositoryTag>();
            builder.Services.AddScoped<IRepositoryTool, RepositoryTool>();
            builder.Services.AddScoped<IRepositoryTransparency, RepositoryTransparency>();
            builder.Services.AddScoped<IRepositoryUnit, RepositoryUnit>();
            builder.Services.AddScoped<IRepositoryGeneratedImage, RepositoryGeneratedImage>();
            builder.Services.AddScoped<IContext, Context>();

            //INJECTION SERVICE
            builder.Services.AddScoped<ServiceColor>();
            builder.Services.AddScoped<ServiceDrink>();
            builder.Services.AddScoped<ServiceFlavour>();
            builder.Services.AddScoped<ServiceGarnish>();
            builder.Services.AddScoped<ServiceGlass>();
            builder.Services.AddScoped<ServiceUploadedImage>();
            builder.Services.AddScoped<ServiceIngridient>();
            builder.Services.AddScoped<ServiceInstruction>();
            builder.Services.AddScoped<ServiceMeasurement>();
            builder.Services.AddScoped<ServiceRecipe>();
            builder.Services.AddScoped<ServiceStyle>();
            builder.Services.AddScoped<ServiceTag>();
            builder.Services.AddScoped<ServiceTool>();
            builder.Services.AddScoped<ServiceTransparency>();
            builder.Services.AddScoped<ServiceUnit>();
            builder.Services.AddScoped<ServiceGeneratedImage>();
            builder.Services.AddScoped<Service>();

            //INJECTION COMMON SERVICE
            builder.Services.AddScoped<CommonServiceMidjourney>();
            builder.Services.AddScoped<CommonServiceBlobStorage>();
            builder.Services.AddScoped<CommonServiceEmail>();
            builder.Services.AddScoped<CommonServicePassword>();
            builder.Services.AddScoped<CommonServiceToken>();
            builder.Services.AddScoped<CommonServiceComputerVision>();

            #endregion Injections

            var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
            builder.Services.AddCors(options =>
            {
                options.AddPolicy(name: MyAllowSpecificOrigins,
                                  builder =>
                                  {
                                      builder.WithOrigins("https://webhook.site");
                                      builder.AllowAnyHeader();
                                  });
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseMigrationsEndPoint();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseCors(MyAllowSpecificOrigins);

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}