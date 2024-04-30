using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using Bakery.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.AspNetCore.Authorization;

namespace Bakery.Controllers
{
    [Authorize(Policy = "Admin")]
    [Route("v1/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly BakeryContext _context;

        private readonly ILogger<AccountController> _logger;
        private readonly IConfiguration _configuration;
        private readonly UserManager<ApiUser> _userManager;
        private readonly SignInManager<ApiUser> _signInManager;
        public AccountController
       (
        BakeryContext context, ILogger<AccountController> logger, IConfiguration configuration,
        UserManager<ApiUser> userManager, SignInManager<ApiUser> signInManager
       )
        {
            _context = context;
            _logger = logger;
            _configuration = configuration;
            _userManager = userManager;
            _signInManager = signInManager;
        }


        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto input)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            //Early return if no user or password
            if (input.Username == null || input.Password == null)
            {
                return BadRequest("Username or password missing");
            }

            var newUser = new ApiUser
            {
                UserName = input.Username
            };

            var result = await _userManager.CreateAsync(newUser, input.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            _logger.LogInformation($"User {newUser.UserName} created a new account");


            Claim claim = new Claim("Rank", input.Rank);

            var claimResult = _userManager.AddClaimAsync(newUser, claim).Result;

            if (!claimResult.Succeeded)
            {
                throw new System.Exception("Failed to seed admin claim");
            }


            return StatusCode(201, $"User {newUser.UserName} created");
        }
        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto input)
        {
            if (input.Username == null || input.Password == null)
            {
                return BadRequest("Username or password missing");
            }

            try
            {
                var user = await _userManager.FindByNameAsync(input.Username);
                if (user == null)
                {
                    return BadRequest("User not found");
                }

                var result = await _signInManager.CheckPasswordSignInAsync(user, input.Password, false);
                if (!result.Succeeded)
                {
                    return BadRequest("Invalid password");
                }

                var signInCrendentials = new SigningCredentials(
                    new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(_configuration["JWT:SigningKey"] ?? throw new Exception("JWT:SigningKey not found"))),
                    SecurityAlgorithms.HmacSha256
                );

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName)
                };

                claims.AddRange((await _userManager.GetClaimsAsync(user)).Select(c => new Claim(c.Type, c.Value)));


                var JwtToken = new JwtSecurityToken(
                    _configuration["JWT:Issuer"],
                    _configuration["JWT:Audience"],
                    claims,
                    expires: DateTime.MaxValue,
                    signingCredentials: signInCrendentials
                );
                var JwtString = new JwtSecurityTokenHandler().WriteToken(JwtToken);

                _logger.LogInformation($"User {user.UserName} logged in");

                return StatusCode(StatusCodes.Status200OK, new { Token = JwtString });
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
                return StatusCode(500, e.Message);
            }
        }
    }
}