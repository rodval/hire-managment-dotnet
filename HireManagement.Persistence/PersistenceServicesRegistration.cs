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
            services.Configure<JwtSettings>(configuration.GetSection("JwtSettings"));

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
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8
                        .GetBytes(configuration["JwtSettings:Key"]!))
                };
            });

            return services;
        }
    }
}
