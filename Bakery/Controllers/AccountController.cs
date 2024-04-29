
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Bakery.Models;
using Serilog;
using Bakery.Dtos;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

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

    public async Task<IActionResult> Register(RegisterDto input)
    {
        if (!ModelState.IsValid)
        {
            return BadRequest(ModelState);
        }

        var newUser = new ApiUser
        {
            UserName = input.Username
        };

        var result = await _userManager.CreateAsync(newUser, input.Password);
        if (result.Succeeded)
        {
            _logger.LogInformation($"User {newUser.UserName} created a new account");
            return StatusCode(201, $"User {newUser.UserName} created");
        }
        else
        {
            return BadRequest(result.Errors);
        }
    }

    public async Task<IActionResult> Login(LoginDto input)
    {

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
                new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"])),
                SecurityAlgorithms.HmacSha256
            );
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.Name, user.UserName)
            };
            var JwtToken = new JwtSecurityToken(
                _configuration["JWT:Issuer"],
                _configuration["JWT:Audience"],
                claims,
                expires: DateTime.Now.AddSeconds(300),
                signingCredentials: signInCrendentials
            );
            var JwtString = new JwtSecurityTokenHandler().WriteToken(JwtToken);

            return StatusCode(StatusCodes.Status200OK, JwtString);
        }
        catch (Exception e)
        {
            _logger.LogError(e.Message);
            return StatusCode(500, "Internal server error");
        }
    }

}