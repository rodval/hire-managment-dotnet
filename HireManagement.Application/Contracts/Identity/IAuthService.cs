using HireManagement.Application.Models.Identity;

namespace HireManagement.Application.Contracts.Identity
{
    public interface IAuthService
    {
        Task<AuthResponse> Login(AuthRequest request, CancellationToken cancellationToken = default);
    }
}
