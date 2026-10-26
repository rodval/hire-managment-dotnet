namespace HireManagement.Application.Responses
{
    public class BaseCommandResponses
    {
        public string? Id { get; set; }
        public bool Success { get; set; } = true;
        public string? Message { get; set; }
        public List<string>? Errors { get; set; }
    }
}
