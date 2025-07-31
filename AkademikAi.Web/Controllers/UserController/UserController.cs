using AkademikAi.Core.DTOs;
using AkademikAi.Entity.Entites;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AkademikAi.Web.Controllers.UserController
{
    
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
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
            var user = await _userManager.FindByEmailAsync(dto.Email);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
                return View(dto);
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName ?? string.Empty, dto.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("dashboard", "User");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid login attempt.");
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
                var user = new AppUser
                {
                    UserName=dto.Email,
                    PhoneNumber = dto.Phone,
                    Email = dto.Email,
                    Name = dto.Name,
                    Surname = dto.Surname,
                    CreatedAt = DateTime.UtcNow,
                    UserRole = AkademikAi.Entity.Enums.UserRole.Student
                    //EmailConfirmed = true // E-posta onayını zorunlu kılmak için
                };
                var result = await _userManager.CreateAsync(user, dto.Password);
                if (result.Succeeded)
                {
                    TempData["SuccessMessage"] = "Registration successful. You can now log in.";
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
            return View("Profile",user);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Dashboard()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return NotFound();
            }
           
            return View("Dashboard", user);
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
                Name = user.Name,
                Surname = user.Surname,
                CreatedAt = user.CreatedAt 
            };
            return Ok(userDto);
        }

        [HttpGet]
        public IActionResult exams()
        {
            return View();
        }
        [HttpGet]
        public IActionResult performance()
        {
            return View();
        }
        [HttpGet]
        public IActionResult solve()
        {
            return View();
        }
       

    }


    
}
