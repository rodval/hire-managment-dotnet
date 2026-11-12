using System.Text;
using HireManagement.Application.Contracts.Identity;
using HireManagement.Application.Contracts.Persistence;
using HireManagement.Application.Models.Identity;
using HireManagement.Persistence.Repositories;
using HireManagement.Persistence.Service;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;

namespace HireManagement.Persistence
{
    public static class PersistenceServicesRegistration
    {
        public static IServiceCollection ConfigurePersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {
            var jwtSection = configuration.GetSection(JwtSettings.SectionName);
            services.AddOptions<JwtSettings>()
                .Bind(jwtSection)
                .ValidateDataAnnotations()
                .ValidateOnStart();

            // Fail fast with a clear message instead of starting with an empty/weak signing key.
            var jwtSettings = jwtSection.Get<JwtSettings>() ?? new JwtSettings();
            if (string.IsNullOrWhiteSpace(jwtSettings.Key) || jwtSettings.Key.Length < 32)
            {
                throw new InvalidOperationException(
                    "JwtSettings:Key is missing or shorter than 32 characters. " +
                    "Set it with 'dotnet user-secrets set \"JwtSettings:Key\" <value>' " +
                    "or the JwtSettings__Key environment variable.");
            }

            services.AddDbContext<HireManagementDbContext>(options =>
               options.UseSqlServer(
                   configuration.GetConnectionString("HireManagementConnectionString")));

            services.AddScoped<IUnitOfWork, UnitOfWork>();

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<ICompanyRepository, CompanyRepository>();
            services.AddScoped<ICompanyEmployeeRepository, CompanyEmployeeRepository>();
            services.AddScoped<IOpeningRepository, OpeningRepository>();
            services.AddScoped<ICandidateRepository, CandidateRepository>();
            services.AddScoped<IOpeningApplicationRepository, OpeningApplicationRepository>();

            services.AddSingleton<IPasswordHasher, PasswordHasher>();
            services.AddScoped<ICandidateAuthService, CandidateAuthService>();
            services.AddScoped<ICompanyEmployeeAuthService, CompanyEmployeeAuthService>();
            services.AddScoped<IAdminApiAuthService, AdminApiAuthService>();

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings.Key)),
                    ValidateIssuer = true,
                    ValidIssuer = jwtSettings.Issuer,
                    ValidateAudience = true,
                    ValidAudience = jwtSettings.Audience,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });

            return services;
        }
    }
}
