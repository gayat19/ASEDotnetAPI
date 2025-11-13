using InventoryAPI.Interfaces;
using InventoryAPI.Models.Dtos;
using InventoryAPI.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;

using Microsoft.AspNetCore.Mvc;

namespace InventoryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [EnableCors("AllowAll")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ILogger<UserController> _logger;

        public UserController(IUserService userService,
                               ILogger<UserController> logger) 
        {
            _userService = userService;
            _logger = logger;

        }
        [HttpPost("Login")]
        public ActionResult Login(LoginRequest loginRequest)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            try
            {
                var result = _userService.Login(loginRequest);
                return Ok(result);
            }
            catch (UnauthorizedAccessException e)
            {
                _logger.LogError(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
            }
            return BadRequest("Invalid username or password");
        }
        [Route("Register")]
        [HttpPost]
        public ActionResult Register(RegisterRequest registerRequest)
        {
            if(!ModelState.IsValid) 
                return BadRequest(ModelState);
            try
            {
                var result = _userService.Register(registerRequest);
                return Ok(result);
            }
            catch(UnauthorizedAccessException e)
            {
                _logger.LogError(e.Message);
            }
            catch (Exception e)
            {
                _logger.LogInformation(e.Message);
            }
            return BadRequest("Unable to register at this time");
        }
    }
}
