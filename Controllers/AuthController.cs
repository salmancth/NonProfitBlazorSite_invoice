
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using NonProfitBlazorSite.Models;
using System.Linq;

namespace NonProfitBlazorSite.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthController : ControllerBase
    {
        private readonly AppDbContext _context;
        public AuthController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterModel model)
        {
            var role = model.Email.Contains("admin") ? "Admin" : "User"; // Basic role assignment logic
            var user = new Member
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Email = model.Email,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                Role = role,
                CreatedDate = DateTime.Now
            };

            _context.Members.Add(user);
            await _context.SaveChangesAsync();

            return Ok(new { message = "Registration successful!", role });
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginModel model)
        {
            var user = _context.Members.FirstOrDefault(u => u.Email == model.Email);
            if (user == null || !BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash))
                return Unauthorized(new { message = "Invalid email or password" });

            return Ok(new { message = "Login successful", role = user.Role });
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("admin-data")]
        public IActionResult GetAdminData()
        {
            return Ok(new { message = "This is admin-only data" });
        }
    }
}
