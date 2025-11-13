using InventoryAPI.Models.Dtos;

namespace InventoryAPI.Interfaces
{
    public interface IUserService
    {
        public RegisterResponse Register(RegisterRequest request);
        public LoginResponse Login(LoginRequest request);
    }
}
