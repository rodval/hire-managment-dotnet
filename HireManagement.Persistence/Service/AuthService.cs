using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using HireManagement.Application.Constants;
using HireManagement.Application.Contracts.Identity;
using HireManagement.Application.Models.Identity;
using HireManagement.Domain.Common;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace HireManagement.Persistence.Service
{
    /// <summary>
    /// Shared login flow for every user type; subclasses only decide which role the token carries.
    /// </summary>
    public abstract class AuthService<TUser> : IAuthService where TUser : Person
    {
        private readonly HireManagementDbContext _dbContext;
        private readonly IPasswordHasher _passwordHasher;
        private readonly JwtSettings _jwtSettings;

        protected AuthService(HireManagementDbContext dbContext, IPasswordHasher passwordHasher, IOptions<JwtSettings> jwtSettings)
        {
            _dbContext = dbContext;
            _passwordHasher = passwordHasher;
            _jwtSettings = jwtSettings.Value;
        }

        protected abstract string GetRole(TUser user);

        public async Task<AuthResponse> Login(AuthRequest request, CancellationToken cancellationToken = default)
        {
            var user = await _dbContext.Set<TUser>()
                .FirstOrDefaultAsync(u => u.Email == request.Email, cancellationToken);

            if (user?.PasswordHash is null || !_passwordHasher.Verify(user.PasswordHash, request.Password ?? string.Empty))
            {
                throw new Exception($"User with {request.Email} not found.");
            }

            var jwtSecurityToken = GenerateToken(user, GetRole(user));

            return new AuthResponse
            {
                Id = user.Id,
                Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken),
                Email = user.Email,
                FirstName = user.FirstName,
                LastName = user.LastName
            };
        }

        private JwtSecurityToken GenerateToken(TUser user, string role)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email ?? string.Empty),
                new Claim(CustomClaimTypes.Uid, user.Id),
                new Claim(ClaimTypes.Role, role)
            };

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSettings.Key!));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);

            return new JwtSecurityToken(
                claims: claims,
                expires: DateTime.UtcNow.AddMinutes(_jwtSettings.DurationInMinutes),
                signingCredentials: signingCredentials);
        }
    }
}
