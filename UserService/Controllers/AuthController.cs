using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using UserService.Data;
using UserService.Dtos;
using UserService.Models;

namespace UserService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly UserDbContext _dbContext;
        private readonly IConfiguration _configuration;

        public AuthController(UserDbContext dbContext, IConfiguration configuration)
        {
            _dbContext = dbContext;
            _configuration = configuration;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto dto)
        {
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);
            if (existingUser != null) return BadRequest("User already exists!");

            var newUser = new User
            {
                UserName = GenerateUserName(dto.FullName),
                Email = dto.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.Password)
            };

            _dbContext.Users.Add(newUser);
            await _dbContext.SaveChangesAsync();
            return Ok("User registered successfully");

        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody]LoginDto dto)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(u => u.Email == dto.Email);

            if(user == null || !BCrypt.Net.BCrypt.Verify(dto.Password,user.PasswordHash))
               return BadRequest("Invalid credentials");

            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["Jwt:Key"]);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[]
                {
                    new Claim(ClaimTypes.NameIdentifier,user.UserId.ToString()),
                    new Claim(ClaimTypes.Email,user.Email),
                    new Claim(ClaimTypes.Role,user.Role)

                }),
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new { Token = tokenHandler.WriteToken(token) });
        }

        public string GenerateUserName(string fullname)
        {
            return fullname.Replace("", ".");
        }

    }
}