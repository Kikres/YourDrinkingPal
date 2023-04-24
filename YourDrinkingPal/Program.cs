using Business_Layer.Data;
using Business_Layer.Services;
using DataLayer.Data;
using DataLayer.Repositories;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace ApplicationLayer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
            builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(connectionString));
            builder.Services.AddDatabaseDeveloperPageExceptionFilter();

            builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
            builder.Services.AddControllersWithViews();

            builder.Services.AddAutoMapper(typeof(DtoMappings));

            #region Injections

            //INJECTION REPOSITORY
            builder.Services.AddScoped<IRepositoryDrink, RepositoryDrink>();
            builder.Services.AddScoped<IRepositoryFlavour, RepositoryFlavour>();
            builder.Services.AddScoped<IRepositoryGlass, RepositoryGlass>();
            builder.Services.AddScoped<IRepositoryIngridient, RepositoryIngridient>();
            builder.Services.AddScoped<IRepositoryInstruction, RepositoryInstruction>();
            builder.Services.AddScoped<IRepositoryMeasurement, RepositoryMeasurement>();
            builder.Services.AddScoped<IRepositoryRecipe, RepositoryRecipe>();
            builder.Services.AddScoped<IRepositoryTag, RepositoryTag>();
            builder.Services.AddScoped<IRepositoryTool, RepositoryTool>();
            builder.Services.AddScoped<IRepositoryUnit, RepositoryUnit>();

            //INJECTION COMMON SERVICE
            builder.Services.AddScoped<ServiceDrink>();
            builder.Services.AddScoped<ServiceFlavour>();
            builder.Services.AddScoped<ServiceTag>();
            builder.Services.AddScoped<ServiceGlass>();
            builder.Services.AddScoped<ServiceUnit>();
            builder.Services.AddScoped<ServiceIngridient>();

            //INJECTION SERVICE
            //builder.Services.AddScoped<IServiceAccessLevelRole, ServiceAccessLevelRole>();

            #endregion Injections

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

            app.UseRouting();

            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");
            app.MapRazorPages();

            app.Run();
        }
    }
}