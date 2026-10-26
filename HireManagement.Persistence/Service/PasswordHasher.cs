using HireManagement.Application.Contracts.Identity;
using Microsoft.AspNetCore.Identity;

namespace HireManagement.Persistence.Service
{
    /// <summary>
    /// Adapter over ASP.NET Core Identity's PBKDF2 password hasher, so the domain and
    /// application layers don't depend on Identity types.
    /// </summary>
    public class PasswordHasher : IPasswordHasher
    {
        private static readonly object HasherUser = new();
        private readonly PasswordHasher<object> _hasher = new();

        public string Hash(string password) =>
            _hasher.HashPassword(HasherUser, password);

        public bool Verify(string hashedPassword, string providedPassword) =>
            _hasher.VerifyHashedPassword(HasherUser, hashedPassword, providedPassword) != PasswordVerificationResult.Failed;
    }
}
