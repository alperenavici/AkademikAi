using AkademikAi.Core.DTOs;
using AkademikAi.Data.Context;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;



namespace AkademikAi.Web.Controllers.Api
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserApiController : ControllerBase
    {

        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private AppDbContext _context;


        public UserApiController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                return BadRequest("Kullanıcı bulunamadı.");
            }

            var result = await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false);
            if (result.Succeeded)
            {
                return Ok("Giriş başarılı.");
            }
            else
            {
                return BadRequest("Geçersiz kullanıcı adı veya şifre.");
            }
        }
        [HttpGet("check-email")]
        public async Task<IActionResult> CheckEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            if (user != null)
            {
                return Ok("Email zaten kayıtlı.");
            }
            return NotFound("Email bulunamadı.");
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName = dto.Email,
                    Email = dto.Email
                };
                var result = await _userManager.CreateAsync(user, dto.Password);
                if (result.Succeeded)
                {
                    return Ok("Kayıt başarılı.");
                }
                else
                {
                    return BadRequest(result.Errors.Select(e => e.Description));
                }
            }
            return BadRequest("Model geçersiz.");
        }

        [HttpPost("Logout")]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Ok("Çıkış başarılı.");

        }
    }
}
