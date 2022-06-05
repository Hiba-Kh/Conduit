using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Conduit.Domain.Models;
using Conduit.Domain.Resources.Requests;
using Conduit.Domain.Resources.Responses;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace Conduit.API.Controllers
{
    [Route("api/users")]
    [ApiController]
    public class IdentityController : ControllerBase
    {
        private readonly UserManager<Users> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public IdentityController(UserManager<Users> userManager, RoleManager<IdentityRole> roleManager, IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login([FromBody] LoginResource resource)
        {
            
            var user = await _userManager.FindByEmailAsync(resource.Email);
            
            if (user != null && await _userManager.CheckPasswordAsync(user, resource.Password))
            {
                var userRoles = await _userManager.GetRolesAsync(user);

                var authClaims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

                foreach (var userRole in userRoles)
                {
                    authClaims.Add(new Claim(ClaimTypes.Role, userRole));
                }

                var token = GetToken(authClaims);

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(token),
                    expiration = token.ValidTo
                });
            }
            return Unauthorized();
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody] RegisterResource resource)
        {
            var userExists = await _userManager.FindByNameAsync(resource.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = "User already exists!" });

            Users user = new()
            {
                Email = resource.Email,
                SecurityStamp = Guid.NewGuid().ToString(),
                UserName = resource.Username
            };
            var result = await _userManager.CreateAsync(user, resource.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new Response { Success = false, Message = "User creation failed! Please check user details and try again." });

            return Ok(new Response { Success = true, Message = "User created successfully!" });
        }


        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetCurrentUser([FromBody] RegisterResource resource)
        {
            return Ok(new Response { Success = true, Message = "User created successfully!" });
        }
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
