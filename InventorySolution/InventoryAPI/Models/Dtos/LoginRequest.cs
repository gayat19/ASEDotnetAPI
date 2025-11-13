using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Models.Dtos
{
    public class LoginRequest
    {
        [Required(ErrorMessage = "Username cannot be empty")]
        public string Username { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password cannot be empty")]
        [MinLength(8, ErrorMessage = "Password should be of minimum 8 chars")]
        public string Password { get; set; } = string.Empty;
    }
}
