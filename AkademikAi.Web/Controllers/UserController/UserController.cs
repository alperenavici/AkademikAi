using AkademikAi.Core.DTOs;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using AkademikAi.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using AkademikAi.Web.Models;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Linq;
using System;

namespace AkademikAi.Web.Controllers.UserController
{
    
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IQuestionService _questionService;
        private readonly ITopicService _topicService;
        private readonly IUserPerformanceSummaryService _performanceService;
        private readonly IUserAnswerService _userAnswerService;
        
        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, 
                            IQuestionService questionService, ITopicService topicService,
                            IUserPerformanceSummaryService performanceService, IUserAnswerService userAnswerService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _questionService = questionService;
            _topicService = topicService;
            _performanceService = performanceService;
            _userAnswerService = userAnswerService;
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
                ModelState.AddModelError(string.Empty, "Geçersiz Kullanıcı Girişi.");
                return View(dto);
            }

            var result = await _signInManager.PasswordSignInAsync(user.UserName ?? string.Empty, dto.Password, isPersistent: false, lockoutOnFailure: false);

            if (result.Succeeded)
            {
                return RedirectToAction("dashboard", "User");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Geçersiz Kullanıcı Girişi");
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
                    return View();
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

        [HttpPost]
        public async Task<IActionResult> UpdateProfile(UpdateProfileViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["ProfileErrorMessage"] = "Lütfen tüm alanları doldurun.";
                return RedirectToAction("Profile");
            }

            var user = await _userManager.GetUserAsync(User); 

            if (user == null)
            {
                return RedirectToAction("Login", "Account");
            }

            user.Name = model.FirstName;
            user.Surname = model.LastName;
            user.PhoneNumber = model.PhoneNumber;

            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                TempData["ProfileSuccessMessage"] = "Bilgileriniz başarıyla güncellendi.";
                return RedirectToAction("Profile"); // Profil sayfasına yönlendir
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }

                return View(model); // Hataları tekrar göster
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto changePassword)
        {
            if (!ModelState.IsValid)
            {
                TempData["PasswordErrorMessage"] = "Lütfen tüm alanları doldurun.";
                return Redirect("/User/Profile#change-password");
            }
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }
            var result =await _userManager.ChangePasswordAsync(user, changePassword.CurrentPassword, changePassword.NewPassword);
            
            if(result.Succeeded)
            {
                TempData["PasswordSuccessMessage"] = "Şifreniz başarıyla değiştirildi.";
                return Redirect("/User/Profile#change-password");
            }
            else
            {
                foreach (var error in result.Errors)
                {
                    TempData["PasswordErrorMessage"] += error.Description + " ";
                }
                return Redirect("/User/Profile#change-password");
            }
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
            var userPerformanceSummaries = await _performanceService.GetUserPerformanceSummariesByUserIdAsync(user.Id);

            var allTopics = await _topicService.GetAllAsync();
            var dailyActivities = await _performanceService.GetDailyActivitiesAsync(user.Id.ToString());

            var performanceData = new PerformanceViewModel
            {
                User = user,
                PerformanceSummaries = userPerformanceSummaries,
                ActivitiesLastYear = dailyActivities,
                AllTopics = allTopics,
                TotalQuestions = userPerformanceSummaries.Sum(p => p.TotalQuestionsAnswered),
                TotalCorrectAnswers = userPerformanceSummaries.Sum(p => p.CorrectAnswers),
                AverageSuccessRate = userPerformanceSummaries.Any() ? userPerformanceSummaries.Average(p => p.SuccessRate) : 0,
                WeakestTopics = userPerformanceSummaries.OrderBy(p => p.SuccessRate).Take(3).ToList()
            };

            return View(performanceData);
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
                PhoneNumber = user.PhoneNumber,
                Email = user.Email,
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
        [Authorize]
        public async Task<IActionResult> performance()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }

            var userPerformanceSummaries = await _performanceService.GetUserPerformanceSummariesByUserIdAsync(user.Id);
            
            var allTopics = await _topicService.GetAllAsync();
            
            var performanceData = new PerformanceViewModel
            {
                User = user,
                PerformanceSummaries = userPerformanceSummaries,
                AllTopics = allTopics,
                TotalQuestions = userPerformanceSummaries.Sum(p => p.TotalQuestionsAnswered),
                TotalCorrectAnswers = userPerformanceSummaries.Sum(p => p.CorrectAnswers),
                AverageSuccessRate = userPerformanceSummaries.Any() ? userPerformanceSummaries.Average(p => p.SuccessRate) : 0,
                WeakestTopics = userPerformanceSummaries.OrderBy(p => p.SuccessRate).Take(3).ToList()
            };

            return View(performanceData);
        }
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> solve()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }

            var mainTopics = await _topicService.GetMainTopicsAsync();
            
            var randomQuestions = await _questionService.GetRandomQuestionsAsync(20);
            
            ViewBag.MainTopics = mainTopics;
            ViewBag.Questions = randomQuestions;
            ViewBag.CurrentUser = user;
            
            return View();
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SubmitSolve([FromBody] List<UserAnswerDto> userAnswers)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }

            if (userAnswers == null || !userAnswers.Any())
            {
                TempData["ErrorMessage"] = "Cevap verisi bulunamadı.";
                return RedirectToAction("solve", "User");
            }

            var result = await _userAnswerService.SubmitUserAnswersAsync(user.Id, userAnswers);

            if (result.IsSuccess)
            {
                TempData["SolveSuccessMessage"] = "Sorular başarıyla kaydedildi.";
                return RedirectToAction("performance", "User");
            }
            else
            {
                TempData["ErrorMessage"] = result.Message;
                return RedirectToAction("solve", "User");
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetFilteredQuestions(string topicId)
        {
            if (string.IsNullOrEmpty(topicId) || !Guid.TryParse(topicId, out Guid topicGuid))
            {
                return Json(new { success = false, message = "Geçersiz konu seçimi" });
            }

            try
            {
                var questions = await _questionService.GetQuestionsByTopicIdAsync(topicGuid);
                var randomQuestions = questions.OrderBy(x => Guid.NewGuid()).Take(20).ToList();
                
                return Json(new { 
                    success = true, 
                    questions = randomQuestions.Select(q => new {
                        id = q.Id,
                        questionText = q.QuestionText,
                        difficultyLevel = q.DifficultyLevel.ToString(),
                        options = q.QuestionsOptions?.Select(o => new {
                            label = o.Label,
                            text = o.OptionText,
                            isCorrect = o.IsCorrect
                        }).OrderBy(o => o.label).ToList(),
                        solutionText = q.SolutionText
                    }).ToList()
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Sorular yüklenirken hata oluştu" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetSubTopics(string parentTopicId)
        {
            if (string.IsNullOrEmpty(parentTopicId) || !Guid.TryParse(parentTopicId, out Guid parentGuid))
            {
                return Json(new { success = false, message = "Geçersiz ana konu" });
            }

            try
            {
                var subTopics = await _topicService.GetSubTopicsAsync(parentGuid);
                return Json(new { 
                    success = true, 
                    subTopics = subTopics.Select(t => new {
                        id = t.Id,
                        name = t.TopicName
                    }).ToList()
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Alt konular yüklenirken hata oluştu" });
            }
        }

        [HttpGet]
        public async Task<IActionResult> GetPerformanceChartData()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { success = false, message = "Kullanıcı bulunamadı" });
            }

            try
            {
                var performanceSummaries = await _performanceService.GetUserPerformanceSummariesByUserIdAsync(user.Id);
                
                // Son 7 günlük veri için örnek veri oluştur (gerçek uygulamada tarih bazlı filtreleme yapılır)
                var chartData = new List<object>();
                var labels = new List<string>();
                var data = new List<double>();

                if (performanceSummaries.Any())
                {
                    // Son 7 gün için örnek veri
                    for (int i = 6; i >= 0; i--)
                    {
                        var date = DateTime.Now.AddDays(-i);
                        labels.Add(date.ToString("dd/MM"));
                        
                        // Bu gün için ortalama başarı oranı (gerçek uygulamada tarih bazlı hesaplanır)
                        var daySuccessRate = performanceSummaries.Average(p => p.SuccessRate);
                        data.Add(Math.Round(daySuccessRate, 1));
                    }
                }
                else
                {
                    // Veri yoksa örnek veri
                    for (int i = 6; i >= 0; i--)
                    {
                        var date = DateTime.Now.AddDays(-i);
                        labels.Add(date.ToString("dd/MM"));
                        data.Add(0);
                    }
                }

                return Json(new { 
                    success = true, 
                    labels = labels,
                    data = data
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Grafik verisi yüklenirken hata oluştu" });
            }
        }
       

    }


    
}
