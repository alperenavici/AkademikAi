using AkademikAi.Core.DTOs;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using AkademikAi.Service.IServices;
using AkademikAi.Service.Services;
using AkademikAi.Web.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace AkademikAi.Web.Controllers.UserController
{
    
    public class UserController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IQuestionService _questionService;
        private readonly ITopicService _topicService;
        private readonly ISubjectService _subjectService;
        private readonly IUserPerformanceSummaryService _performanceService;
        private readonly IUserAnswerService _userAnswerService;
        private readonly IExamService _examService;

        public UserController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, 
                            IQuestionService questionService, ITopicService topicService, ISubjectService subjectService,
                            IUserPerformanceSummaryService performanceService, IUserAnswerService userAnswerService, IExamService examService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _questionService = questionService;
            _topicService = topicService;
            _subjectService = subjectService;
            _performanceService = performanceService;
            _userAnswerService = userAnswerService;
            _examService = examService;
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

            // Eğer kullanıcı Teacher ise Admin paneline yönlendir
            if (user.UserRole == UserRole.Teacher)
            {
                return RedirectToAction("Index", "Admin");
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


        [Authorize]
        public async Task<IActionResult> Exams()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return RedirectToAction("Login", "User");
            }
            
            var subjects = await _subjectService.GetActiveSubjectsAsync();
            var availableExams = await _examService.GetAdminExamsOnlyAsync(); // Sadece admin sınavları
            
            ViewBag.Subjects = subjects;
            ViewBag.AvailableExams = availableExams;
            return View(user);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken] 
        public async Task<IActionResult> CreateCustomExam(CustomExamCreateDto dto)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Lütfen tüm alanları doğru bir şekilde doldurun." });
            }

            try
            {
                var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userIdClaim))
                    return Json(new { success = false, message = "Kullanıcı kimliği bulunamadı." });
                    
                var userId = Guid.Parse(userIdClaim);
                var newExamId = await _examService.CreateCustomExamFromUserRequestAsync(dto, userId);

                return Json(new { success = true, message = "Özel testiniz başarıyla oluşturuldu!", examId = newExamId });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }
        [HttpGet]
        public async Task<IActionResult> StartAndGetExam(Guid examId)
        {
            if (examId == Guid.Empty)
            {
                return Json(new { success = false, message = "Geçersiz sınav ID'si." });
            }

            try
            {
                var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

                await _examService.StartExamForUserAsync(examId, userId);

                var examDetails = await _examService.GetExamForStudentAsync(examId, userId);

                return Json(new { success = true, exam = examDetails });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Sınav yüklenirken bir hata oluştu: " + ex.Message });
            }
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
            var subjects = await _subjectService.GetActiveSubjectsAsync();
            

            ViewBag.Subjects = subjects;

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
            
            // Kullanıcının kayıtlı olduğu sınavları getir
            var registeredExams = await _examService.GetUserRegisteredExamsAsync(user.Id);
            
            ViewBag.MainTopics = mainTopics;
            ViewBag.Questions = randomQuestions;
            ViewBag.CurrentUser = user;
            ViewBag.RegisteredExams = registeredExams;
            
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
        [Authorize]
        public async Task<IActionResult> GetSubTopics(string parentTopicId)
        {
            // Guid kontrolünüz zaten doğru, aynen kalabilir.
            if (string.IsNullOrEmpty(parentTopicId) || !Guid.TryParse(parentTopicId, out Guid parentGuid))
            {
                // Direkt olarak bir hata nesnesi dönebiliriz.
                return BadRequest(new { message = "Geçersiz ana konu ID'si." });
            }

            try
            {
                var subTopics = await _topicService.GetSubTopicsAsync(parentGuid);

                
                var result = subTopics.Select(t => new {
                    id = t.Id,
                    topicName = t.TopicName 
                }).ToList();

                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return StatusCode(500, new { message = "Sunucu hatası: Alt konular yüklenemedi." });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> CustomExam(Guid? examId)
        {
            ViewBag.ExamId = examId;
            return View();
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetTopicsBySubject(string subjectId)
        {
            if (string.IsNullOrEmpty(subjectId) || !Guid.TryParse(subjectId, out Guid subjectGuid))
            {
                return BadRequest(new { message = "Geçersiz ders ID'si." });
            }

            try
            {
                var topics = await _topicService.GetTopicsBySubjectIdAsync(subjectGuid);

                var result = topics.Select(t => new {
                    id = t.Id,
                    topicName = t.TopicName
                }).ToList();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Sunucu hatası: Konular yüklenemedi." });
            }
        }

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> SubmitExam([FromBody] SubmitExamRequest request)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, message = "Geçersiz veri gönderildi." });
            }

            try
            {
                var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (string.IsNullOrEmpty(userIdClaim))
                    return Json(new { success = false, message = "Kullanıcı kimliği bulunamadı." });
                    
                var userId = Guid.Parse(userIdClaim);
                
                // Test kaydetme işlemini başlat
                var score = await _examService.SubmitAndScoreExamAsync(request.ExamId, userId, request.Answers);

                // Calculate statistics from submitted answers
                var totalQuestions = request.Answers.Count; 
                var successRate = score;
                var correctAnswers = (int)Math.Round((score / 100.0) * totalQuestions);
                var wrongAnswers = totalQuestions - correctAnswers;

                // Log işlem başarısı
                System.Diagnostics.Debug.WriteLine($"✅ Test başarıyla kaydedildi - ExamId: {request.ExamId}, UserId: {userId}, Score: {score}");

                return Json(new 
                { 
                    success = true, 
                    score = score,
                    correctAnswers = correctAnswers,
                    wrongAnswers = wrongAnswers,
                    successRate = successRate,
                    totalQuestions = totalQuestions,
                    message = "Test başarıyla tamamlandı ve kaydedildi! 🎉"
                });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }



        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserExamHistory()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { success = false, message = "Kullanıcı bulunamadı" });
            }

            try
            {
                var userExams = await _examService.GetUserExamHistoryAsync(user.Id);

                var result = userExams.Select(exam => new {
                    examName = exam.Title,
                    date = exam.CreatedAt.ToString("dd.MM.yyyy"),
                    score = exam.Score?.ToString("F1") ?? "0.0",
                    correctAnswers = exam.CorrectAnswers,
                    wrongAnswers = exam.WrongAnswers,
                    successRate = exam.SuccessRate?.ToString("F0") ?? "0",
                    examId = exam.Id
                }).ToList();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Sınav geçmişi yüklenirken hata oluştu." });
            }
        }

        

        [HttpPost]
        [Authorize]
        public async Task<IActionResult> RegisterForExam(Guid examId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { success = false, message = "Kullanıcı bulunamadı" });
            }

            try
            {
                await _examService.RegisterUserForExamAsync(examId, user.Id);
                return Json(new { success = true, message = "Sınava başarıyla kaydoldunuz!" });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserRegisteredExams()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { success = false, message = "Kullanıcı bulunamadı" });
            }

            try
            {
                var registeredExams = await _examService.GetUserRegisteredExamsAsync(user.Id);
                var result = registeredExams.Select(exam => new {
                    id = exam.Id,
                    title = exam.Title,
                    description = exam.Description,
                    startTime = exam.StartTime.ToString("dd.MM.yyyy HH:mm"),
                    endTime = exam.EndTime.ToString("dd.MM.yyyy HH:mm"),
                    durationMinutes = exam.DurationMinutes,
                    status = exam.Status.ToString(),
                    canStart = exam.Status == "InProgress" && exam.StartTime <= DateTime.Now && exam.EndTime >= DateTime.Now
                }).ToList();

                return Ok(result);
            }
            catch (Exception)
            {
                return StatusCode(500, new { message = "Kayıtlı sınavlar yüklenirken hata oluştu." });
            }
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> GetUserRegisteredExamsForSolve()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null)
            {
                return Json(new { success = false, message = "Kullanıcı bulunamadı" });
            }

            try
            {
                var registeredExams = await _examService.GetUserRegisteredExamsAsync(user.Id);
                var result = registeredExams.Where(exam => exam.Status == "Scheduled" || exam.Status == "InProgress")
                    .Select(exam => new {
                        id = exam.Id,
                        title = exam.Title,
                        description = exam.Description,
                        startTime = exam.StartTime.ToString("dd.MM.yyyy HH:mm"),
                        endTime = exam.EndTime.ToString("dd.MM.yyyy HH:mm"),
                        durationMinutes = exam.DurationMinutes,
                        status = exam.Status.ToString(),
                        canStart = exam.Status == "InProgress" && exam.StartTime <= DateTime.Now && exam.EndTime >= DateTime.Now
                    }).ToList();

                return Json(new { success = true, exams = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
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
                
                var chartData = new List<object>();
                var labels = new List<string>();
                var data = new List<double>();

                if (performanceSummaries.Any())
                {
                    for (int i = 6; i >= 0; i--)
                    {
                        var date = DateTime.Now.AddDays(-i);
                        labels.Add(date.ToString("dd/MM"));
                        
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
            catch (Exception)
            {
                return Json(new { success = false, message = "Grafik verisi yüklenirken hata oluştu" });
            }
        }

        

    }


    
}
