using AutoMapper;
using InventoryAPI.Interfaces;
using InventoryAPI.Models;
using InventoryAPI.Models.Dtos;
using InventoryAPI.Repositories;
using System.Security.Cryptography;
using System.Text;

namespace InventoryAPI.Services
{
    public class UserService : IUserService
    {
        private readonly IRepository<string, User> _userRepository;
        private readonly IMapper _mapper;
        private readonly ILogger<UserService> _logger;

        public UserService(IRepository<string,User> userRepository,
                            IMapper mapper,
                            ILogger<UserService> logger) 
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _logger = logger;
        }

        public LoginResponse Login(LoginRequest request)
        {
            var dbUser = _userRepository.GetById(request.Username);
            byte[] key;
            if (dbUser == null) 
                throw new UnauthorizedAccessException("No such user with teh username " + request.Username);
            var encryptedPass = ComputeHashWithKey(dbUser.PasswordHash, request.Password,out key);
            for (var i = 0; i < encryptedPass.Length; i++)
            {
                if (encryptedPass[i] != dbUser.Password[i])
                    throw new UnauthorizedAccessException("Invalid Password");
            }
            return new LoginResponse
            {
                Username = request.Username,
                Token = ""
            };
        }

        public RegisterResponse Register(RegisterRequest request)
        {
            byte[] key;
            var user = new User
            {
                Username = request.Username,
                Role = request.Role,
                Password = ComputeHashWithKey(null,request.Password,out key),
                PasswordHash = key
            };
            var dbUser = _userRepository.Add(user);
            if (dbUser != null)
                return new RegisterResponse { Username = request.Username };
            throw new Exception("Unable to register user");

        }
        private byte[] ComputeHashWithKey(byte[]? preDefinedKey,string pass, out byte[] key)
        {
            HMACSHA256 hmac;
            if (preDefinedKey == null)
                hmac = new HMACSHA256();
            else
                hmac = new HMACSHA256(preDefinedKey);
            key = hmac.Key;
            var result = hmac.ComputeHash(Encoding.UTF8.GetBytes(pass));
            return result; 
        }
    }
}
