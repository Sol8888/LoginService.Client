using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace LoginService.Client.Models
{
    public class LoginRequest
    {
        [Required]
        [JsonPropertyName("username")]
        public string Username { get; set; } = string.Empty;

        [Required]
        [JsonPropertyName("password")]
        public string Password { get; set; } = string.Empty;
    }
}