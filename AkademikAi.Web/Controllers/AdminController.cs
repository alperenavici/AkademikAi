using AkademikAi.Core.DTOs;
using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using AkademikAi.Service.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace AkademikAi.Web.Controllers
{
    [Authorize]
    public class AdminController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly IExamService _examService;
        private readonly ISubjectService _subjectService;
        private readonly ITopicService _topicService;
        private readonly IQuestionService _questionService;

        public AdminController(
            UserManager<AppUser> userManager,
            IExamService examService,
            ISubjectService subjectService,
            ITopicService topicService,
            IQuestionService questionService)
        {
            _userManager = userManager;
            _examService = examService;
            _subjectService = subjectService;
            _topicService = topicService;
            _questionService = questionService;
        }

        // Admin ana sayfası
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || user.UserRole != UserRole.Teacher)
            {
                return RedirectToAction("Dashboard", "User");
            }

            return View();
        }

        // Sınav Yönetimi Ana Sayfası
        public async Task<IActionResult> ExamManagement()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || user.UserRole != UserRole.Teacher)
            {
                return RedirectToAction("Dashboard", "User");
            }

            var exams = await _examService.GetAllExamsAsync();
            return View(exams);
        }

        // Sınav Oluşturma Sayfası
        [HttpGet]
        public async Task<IActionResult> CreateExam()
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || user.UserRole != UserRole.Teacher)
            {
                return RedirectToAction("Dashboard", "User");
            }

            var subjects = await _subjectService.GetActiveSubjectsAsync();
            ViewBag.Subjects = subjects;
            return View(new ExamCreateDto());
        }

        // Sınav Oluşturma - POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateExam(ExamCreateDto examDto)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || user.UserRole != UserRole.Teacher)
            {
                return RedirectToAction("Dashboard", "User");
            }

            if (!ModelState.IsValid)
            {
                var subjects = await _subjectService.GetActiveSubjectsAsync();
                ViewBag.Subjects = subjects;
                return View(examDto);
            }

            try
            {
                await _examService.CreateExamAsync(examDto);
                TempData["SuccessMessage"] = "Sınav başarıyla oluşturuldu!";
                return RedirectToAction("ExamManagement");
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Sınav oluşturulurken bir hata oluştu: " + ex.Message);
                var subjects = await _subjectService.GetActiveSubjectsAsync();
                ViewBag.Subjects = subjects;
                return View(examDto);
            }
        }

        // Konuya göre soru getirme
        [HttpGet]
        public async Task<IActionResult> GetQuestionsByTopic(Guid topicId)
        {
            try
            {
                var questions = await _questionService.GetQuestionsByTopicIdAsync(topicId);
                var result = questions.Select(q => new {
                    id = q.Id,
                    questionText = q.QuestionText,
                    difficultyLevel = q.DifficultyLevel.ToString(),
                    source = q.Source
                }).ToList();

                return Json(new { success = true, questions = result });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // Sınav Detayları
        [HttpGet]
        public async Task<IActionResult> ExamDetails(Guid id)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || user.UserRole != UserRole.Teacher)
            {
                return RedirectToAction("Dashboard", "User");
            }

            try
            {
                var exam = await _examService.GetExamForStudentAsync(id, user.Id);
                return View(exam);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Sınav bulunamadı: " + ex.Message;
                return RedirectToAction("ExamManagement");
            }
        }

        // Sınav Durumu Güncelleme
        [HttpPost]
        public async Task<IActionResult> UpdateExamStatus(Guid examId, ExamStatus status)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || user.UserRole != UserRole.Teacher)
            {
                return Json(new { success = false, message = "Yetkiniz yok." });
            }

            try
            {
                // Bu method ExamService'e eklenecek
                //await _examService.UpdateExamStatusAsync(examId, status);
                return Json(new { success = true, message = "Sınav durumu güncellendi." });
            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = ex.Message });
            }
        }

        // Sınav Katılımcıları
        [HttpGet]
        public async Task<IActionResult> ExamParticipants(Guid examId)
        {
            var user = await _userManager.GetUserAsync(User);
            if (user == null || user.UserRole != UserRole.Teacher)
            {
                return RedirectToAction("Dashboard", "User");
            }

            try
            {
                // Bu method ExamService'e eklenecek
                //var participants = await _examService.GetExamParticipantsAsync(examId);
                //return View(participants);
                return View();
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Katılımcılar yüklenemedi: " + ex.Message;
                return RedirectToAction("ExamManagement");
            }
        }
    }
}
