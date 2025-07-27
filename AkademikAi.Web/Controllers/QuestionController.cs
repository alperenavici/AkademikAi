using AkademikAi.Entity.Entites;
using AkademikAi.Entity.Enums;
using AkademikAi.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademikAi.Web.Controllers
{
    public class QuestionController : Controller
    {
        private readonly IQuestionService _questionService;
        private readonly ITopicService _topicService;

        public QuestionController(IQuestionService questionService, ITopicService topicService)
        {
            _questionService = questionService;
            _topicService = topicService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var questions = await _questionService.GetActiveQuestionsAsync();
                return View(questions);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                return View(new List<Questions>());
            }
        }

        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var question = await _questionService.GetQuestionByIdAsync(id);
                if (question == null)
                {
                    TempData["Error"] = "Soru bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                return View(question);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Create()
        {
            try
            {
                var topics = await _topicService.GetAllAsync();
                ViewBag.Topics = topics;
                return View();
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("QuestionText,DifficultyLevel,Source,SolutionText,GeneratedForUserId")] Questions question, List<Guid> topicIds, List<string> options)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createdQuestion = await _questionService.CreateQuestionAsync(question, topicIds, options);
                    TempData["Success"] = "Soru başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Details), new { id = createdQuestion.Id });
                }

                var topics = await _topicService.GetAllAsync();
                ViewBag.Topics = topics;
                return View(question);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                var topics = await _topicService.GetAllAsync();
                ViewBag.Topics = topics;
                return View(question);
            }
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var question = await _questionService.GetQuestionByIdAsync(id);
                if (question == null)
                {
                    TempData["Error"] = "Soru bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                var topics = await _topicService.GetAllAsync();
                ViewBag.Topics = topics;
                return View(question);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,QuestionText,DifficultyLevel,Source,SolutionText,IsActive")] Questions question, List<Guid> topicIds, List<string> options)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _questionService.UpdateQuestionAsync(question, topicIds, options);
                    if (result)
                    {
                        TempData["Success"] = "Soru başarıyla güncellendi.";
                        return RedirectToAction(nameof(Details), new { id = question.Id });
                    }
                    else
                    {
                        TempData["Error"] = "Soru güncellenirken hata oluştu.";
                    }
                }

                var topics = await _topicService.GetAllAsync();
                ViewBag.Topics = topics;
                return View(question);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                var topics = await _topicService.GetAllAsync();
                ViewBag.Topics = topics;
                return View(question);
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var question = await _questionService.GetQuestionByIdAsync(id);
                if (question == null)
                {
                    TempData["Error"] = "Soru bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                return View(question);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                var result = await _questionService.DeactivateQuestionAsync(id);
                if (result)
                {
                    TempData["Success"] = "Soru başarıyla silindi.";
                }
                else
                {
                    TempData["Error"] = "Soru silinirken hata oluştu.";
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> RandomQuestions(int count = 10, int? difficulty = null, Guid? topicId = null)
        {
            try
            {
                QuestionsDiff? difficultyEnum = difficulty.HasValue ? (QuestionsDiff)difficulty.Value : null;
                var questions = await _questionService.GetRandomQuestionsAsync(count, difficultyEnum, topicId);
                return View(questions);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                return View(new List<Questions>());
            }
        }

        public async Task<IActionResult> ByDifficulty(int difficulty)
        {
            try
            {
                var difficultyEnum = (QuestionsDiff)difficulty;
                var questions = await _questionService.GetQuestionsByDifficultyAsync(difficultyEnum);
                ViewBag.Difficulty = difficultyEnum;
                return View(questions);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                return View(new List<Questions>());
            }
        }

        public async Task<IActionResult> ByTopic(Guid topicId)
        {
            try
            {
                var questions = await _questionService.GetQuestionsByTopicIdAsync(topicId);
                var topic = await _topicService.GetByIdAsync(topicId);
                ViewBag.Topic = topic;
                return View(questions);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                return View(new List<Questions>());
            }
        }
    }
} 