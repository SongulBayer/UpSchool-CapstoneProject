using FinalProject.Application.Common.Interfaces;
using FinalProject.Domain.Identity;
using FinalProject.Infrastructure.Persistance.Configurations.Context;
using FinalProject.Infrastructure.Services;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace FinalProject.Infrastructure
{
    public static class ConfigureServiceRegistration
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services,
            IConfiguration configuration, string wwwrootPath)
        {
            AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
            var connectionString = configuration.GetConnectionString("PostgreSQL")!;

            // DbContext
            services.AddDbContext<ApplicationDbContext>(opt => opt.UseNpgsql(connectionString, b => b.MigrationsAssembly("FinalProject.WebApi")));

            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.AddDbContext<IdentityContext>(opt => opt.UseNpgsql(connectionString, b => b.MigrationsAssembly("FinalProject.WebApi")));

            services.AddDbContext<IdentityContext>(opt => opt.UseNpgsql(connectionString, b => b.MigrationsAssembly("FinalProject.WebApi")));
            services.AddIdentity<User, Role>(options =>
            {

                // User Password Options
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireUppercase = false;
                // User Username and Email Options
                options.User.AllowedUserNameCharacters = "abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789-._@+$";
                options.User.RequireUniqueEmail = true;

            }).AddEntityFrameworkStores<IdentityContext>()
                .AddDefaultTokenProviders();

            // Scoped Services
            services.AddScoped<IAuthenticationService, AuthenticationManager>();


            // Singleton Services
            services.AddSingleton<IJwtService, JwtManager>();
            services.AddSingleton<IEmailService, EmailManager>();

            return services;
        }
    }
}
