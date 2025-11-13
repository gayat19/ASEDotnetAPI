using InventoryAPI.Models.Dtos;

namespace InventoryAPI.Interfaces
{
    public interface IUserService
    {
        // <summary>
        /// This method registers a new user
        /// </summary>
        /// <param name="request">Needs the username and password</param>
        /// <returns>Gives back an object withj username</returns>
        /// <exception cref="Exception">If the registration fails then thows this one</exception>
        public RegisterResponse Register(RegisterRequest request);
        public LoginResponse Login(LoginRequest request);
    }
}
