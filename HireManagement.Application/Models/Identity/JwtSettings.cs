using System.ComponentModel.DataAnnotations;

namespace HireManagement.Application.Models.Identity
{
    public class JwtSettings
    {
        public const string SectionName = "JwtSettings";

        /// <summary>
        /// HMAC-SHA256 signing key. Never commit it: supply it through user secrets
        /// (development) or the <c>JwtSettings__Key</c> environment variable (other environments).
        /// </summary>
        [Required(ErrorMessage = "JwtSettings:Key is not configured. Set it with user secrets or the JwtSettings__Key environment variable.")]
        [MinLength(32, ErrorMessage = "JwtSettings:Key must be at least 32 characters (256 bits) for HMAC-SHA256.")]
        public string Key { get; set; } = string.Empty;

        [Required]
        public string Issuer { get; set; } = string.Empty;

        [Required]
        public string Audience { get; set; } = string.Empty;

        [Range(1, 1440)]
        public double DurationInMinutes { get; set; }
    }
}
