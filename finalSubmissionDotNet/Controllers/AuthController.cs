using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using finalSubmission.Core.Domain.Entities;
using ContactsManager.Core.Domain.IdentityEntities;
using Microsoft.AspNetCore.Authorization;
using finalSubmission.Core.ServiceContracts.IUserService;

namespace finalSubmissionDotNet.Controllers
{
    [Route("api/[controller]")]
    [AllowAnonymous]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<ApplicationRole> _roleManager;
        private readonly IConfiguration _configuration;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ICreateUser _createUser;

        public AuthController(
            UserManager<ApplicationUser> userManager,
            RoleManager<ApplicationRole> roleManager,
            IConfiguration configuration,
            SignInManager<ApplicationUser> signInManager, ICreateUser createUser)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
            _signInManager = signInManager;
            _createUser = createUser;
        }

        public enum UserType{
            Admin, User
            }

        /// <summary>
        /// Register a new user
        /// </summary>
        [HttpPost("[action]/{usertype}")]
        public async Task<IActionResult> Register([FromBody] RegisterUser model,[FromRoute] UserType usertype)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = new ApplicationUser
            {
                UserName = model.UserName
            };

            User user1 = new User() { UserName = model.UserName, UserId = Guid.NewGuid() };

            await _createUser.CreateAnUser(user1);

            var result = await _userManager.CreateAsync(user, model.Password);

            if (!result.Succeeded)
            {
                return BadRequest(result.Errors);
            }

            // Assign default role (User)
            if (await _roleManager.RoleExistsAsync(usertype.ToString()))
            {
                await _userManager.AddToRoleAsync(user, usertype.ToString());
            }

            return Ok(new { message = "User registered successfully!" });
        }

        /// <summary>
        /// Login a user and generate a JWT token
        /// </summary>
        [HttpPost("[action]")]
        public async Task<IActionResult> Login([FromBody] LoginUser model)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var user = await _userManager.FindByNameAsync(model.UserName);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
            {
                return Unauthorized(new { message = "Invalid username or password" });
            }

            var roles = await _userManager.GetRolesAsync(user);

            var claims = new List<Claim>
    {
        new Claim(ClaimTypes.Name, user.UserName),
        new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),  // Add UserId here
        new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
    };

            claims.AddRange(roles.Select(role => new Claim(ClaimTypes.Role, role)));

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]!));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(1),
                signingCredentials: creds
            );

            return Ok(new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }


        [HttpPost("[action]")]
        public IActionResult Logout()
        {
            // Sign out the user
            _signInManager.SignOutAsync();

            // Optional: Return a success message
            return Ok(new { message = "Logout successful" });
        }
    }
}
