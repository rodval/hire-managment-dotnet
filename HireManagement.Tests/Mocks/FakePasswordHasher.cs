using HireManagement.Application.Contracts.Identity;

namespace HireManagement.Tests.Mocks
{
    public class FakePasswordHasher : IPasswordHasher
    {
        public string Hash(string password) => $"hashed:{password}";

        public bool Verify(string hashedPassword, string providedPassword) =>
            hashedPassword == Hash(providedPassword);
    }
}
