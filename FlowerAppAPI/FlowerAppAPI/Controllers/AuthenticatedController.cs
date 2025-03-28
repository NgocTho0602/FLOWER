﻿using FlowerAppAPI.Model;
using FlowerAppAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FlowerAppAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticateController : ControllerBase
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IConfiguration _configuration;

        public AuthenticateController(
            UserManager<User> userManager,
            RoleManager<IdentityRole> roleManager,
            IConfiguration configuration)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var userExists = await _userManager.FindByNameAsync(model.Username);
            if (userExists != null)
                return StatusCode(StatusCodes.Status400BadRequest, new { Status = false, Message = "User already exists" });

            var user = new User
            {
                UserName = model.Username,
                Email = model.Email,
                Initials = model.Initials
            };

            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return StatusCode(StatusCodes.Status500InternalServerError, new { Status = false, Message = "User creation failed" });

            // Assign Role if Provided
            if (!string.IsNullOrEmpty(model.Role))
            {
                if (!await _roleManager.RoleExistsAsync(model.Role))
                {
                    await _roleManager.CreateAsync(new IdentityRole(model.Role));
                }
                await _userManager.AddToRoleAsync(user, model.Role);
            }

            return Ok(new { Status = true, Message = "User created successfully" });
        }
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var user = await _userManager.FindByNameAsync(model.Username);
            if (user == null || !await _userManager.CheckPasswordAsync(user, model.Password))
                return Unauthorized(new { Status = false, Message = "Invalid username or password" });

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
{
    new Claim(ClaimTypes.Name, user.UserName),
    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
};

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole));
            }

            var token = GenerateToken(authClaims);
            return Ok(new { Status = true, Message = "Logged in successfully", Token = token, UserId = user.Id });
        }

        [HttpGet("get-user/{UserName}")]
        // Nếu cần bảo mật, yêu cầu JWT Token
        public async Task<IActionResult> GetUserById(string UserName)
        {
            // Tìm người dùng theo ID
            var user = await _userManager.FindByNameAsync(UserName);
            if (user == null)
            {
                return NotFound(new { Status = false, Message = "User not found" });
            }

            // Trả về thông tin người dùng
            return Ok(new
            {
                Status = true,
                Data = new
                {
                    user.Id,
                    user.UserName,
                    user.Email,
                    user.Initials,
                    user.PhoneNumber,
                    user.SecurityStamp // Thêm các thuộc tính cần thiết
                }
            });
        }
        [HttpPut("edit-profile/{UserName}")]
  public async Task<IActionResult> EditUserProfile(string UserName, [FromBody] EditUserProfileRequest request)
  {
      if (!ModelState.IsValid)
      {
          return BadRequest(new { Status = false, Message = "Invalid data", Errors = ModelState.Values.SelectMany(v => v.Errors.Select(e => e.ErrorMessage)) });
      }

      var user = await _userManager.FindByNameAsync(UserName);
      if (user == null)
      {
          return NotFound(new { Status = false, Message = "User not found" });
      }

      // Cập nhật thông tin người dùng
      user.Email = request.Email;
      user.PhoneNumber = request.PhoneNumber;
      user.UserName = request.UserName;
       // Giả sử bạn có thuộc tính `FullName` trong model
   

      var result = await _userManager.UpdateAsync(user);
      if (!result.Succeeded)
      {
          return StatusCode(500, new { Status = false, Message = "Failed to update user", Errors = result.Errors.Select(e => e.Description) });
      }

      return Ok(new { Status = true, Message = "User profile updated successfully" });
  }
        [HttpPost("logout")]
        [Authorize]
        public IActionResult Logout()
        {
            // Không cần làm gì ở phía server vì JWT là stateless
            return Ok(new { Status = true, Message = "Logged out successfully" });
        }
        private string GenerateToken(IEnumerable<Claim> claims)
        {
            var jwtSettings = _configuration.GetSection("JWTKey");
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtSettings["Secret"]));

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddHours(Convert.ToDouble(jwtSettings["TokenExpiryTimeInHour"])),
                Issuer = jwtSettings["ValidIssuer"],
                Audience = jwtSettings["ValidAudience"],
                SigningCredentials = new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            };

            var tokenHandler = new JwtSecurityTokenHandler();
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}
