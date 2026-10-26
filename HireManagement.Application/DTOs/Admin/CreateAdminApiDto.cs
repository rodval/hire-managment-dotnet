namespace HireManagement.Application.DTOs.Admin
{
    public class CreateAdminApiDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public int? Age { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
