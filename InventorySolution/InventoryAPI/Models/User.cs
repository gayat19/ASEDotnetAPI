using System.ComponentModel.DataAnnotations;

namespace InventoryAPI.Models
{
    public class User
    {
        [Key]
        public required string Username { get; set; }
        public required byte[] Password { get; set; }
        public required byte[] PasswordHash { get; set; }

        public string Role { get; set; } = "User";
    }
}
