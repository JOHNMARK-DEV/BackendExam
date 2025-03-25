using BackendExam.Contracts;
using BackendExam.Models;
using BackendExam.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace BackendExam.Controllers
{ 
    [ApiController]
    public class AuthController:ControllerBase
    { 
        private readonly UserManager<UserModel> _userManager;
        private readonly SignInManager<UserModel> _signInManager;
        private readonly IAuthService _authService;

        public AuthController(UserManager<UserModel> userManager,SignInManager<UserModel> signInManager,IAuthService authService)
        {
            _signInManager = signInManager;
            _userManager = userManager; 
            _authService = authService; 
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            try
            {
                var result = await _authService.Register(model);
                if (result)
                {
                    return Ok(new { Message = "Registration successful." });
                }

                return BadRequest();
            }
            catch (Exception)
            {

                throw;
            }
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            
            var tokenResponse = _authService.Authenticate(model.Email, model.Password);

            if (tokenResponse != null)
            {
                 return Ok(tokenResponse.ToString());
            }

            return Unauthorized("Invalid credentials");
        }

        [Authorize]
        [HttpGet("user/me")]
        public IActionResult Me()
        {

            if (User.Identity.IsAuthenticated)
            {
                var Name = User.Identity.Name;

                return Ok(new { Name });
            }
 

            return Unauthorized("Invalid credentials");
        }
    }
}
