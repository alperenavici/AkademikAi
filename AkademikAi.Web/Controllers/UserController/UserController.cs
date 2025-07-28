using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using AkademikAi.Core.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;


namespace AkademikAi.Web.Controllers.UserController
{
    
    public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        public UserController(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginDto dto)
        {
            var user=await _userManager.FindByEmailAsync(dto.Email);
            if(user==null)
            {
                ModelState.AddModelError(string.Empty, "Geçersiz Giriş İsteği");
                return View(dto);
            }
            
            var result =await _signInManager.CheckPasswordSignInAsync(user, dto.Password, false); //false 3 defa yanlış girerse kitleme
            if(result.Succeeded)
            {
                return RedirectToAction("Profile", "User");
            }
            else 
            { 
                ViewBag.ErrorA(string.Empty, "Geçersiz Giriş İsteği");
                return View(dto); 
            }
                

        }
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }   

        [HttpGet]
        public IActionResult Register() 
        {
                return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto dto)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser
                {
                    UserName=dto.Email,
                    Email = dto.Email
                    //EmailConfirmed = true // E-posta onayını zorunlu kılmak için
                };
                var result = await _userManager.CreateAsync(user, dto.Password);
                if (result.Succeeded)
                {
                   
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError(string.Empty, error.Description);
                    }
                }
            }
            return View(dto);
        }

        [HttpGet]
        [Authorize]
        public IActionResult Profile()
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                return NotFound();
            }
            return View("Dashboard",user);
        }

        [HttpGet]
        public IActionResult GetUser()
        {
            var user = _userManager.GetUserAsync(User).Result;
            if (user == null)
            {
                return NotFound();
            }
            var userDto = new UserDto
            {
                Name = user.UserName,
                Surname = user.Email,
                CreatedAt = DateTime.UtcNow 
            };
            return Ok(userDto);
        }
        

    }


    
}
