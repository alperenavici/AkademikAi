using AkademikAi.Entity.Entites;
using AkademikAi.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademikAi.Web.Controllers
{
    public class TopicController : Controller
    {
        private readonly ITopicService _topicService;

        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        public async Task<IActionResult> Index()
        {
            try
            {
                var topics = await _topicService.GetAllAsync();
                return View(topics);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                return View(new List<Topics>());
            }
        }

        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var topic = await _topicService.GetByIdAsync(id);
                if (topic == null)
                {
                    TempData["Error"] = "Konu bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                return View(topic);
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
                var topics = await _topicService.GetMainTopicsAsync();
                ViewBag.ParentTopics = topics;
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
        public async Task<IActionResult> Create([Bind("TopicName,ParentTopicId")] Topics topic)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var createdTopic = await _topicService.CreateTopicAsync(topic.TopicName, topic.ParentTopicId);
                    TempData["Success"] = "Konu başarıyla oluşturuldu.";
                    return RedirectToAction(nameof(Details), new { id = createdTopic.Id });
                }

                var topics = await _topicService.GetMainTopicsAsync();
                ViewBag.ParentTopics = topics;
                return View(topic);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                var topics = await _topicService.GetMainTopicsAsync();
                ViewBag.ParentTopics = topics;
                return View(topic);
            }
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {
                var topic = await _topicService.GetByIdAsync(id);
                if (topic == null)
                {
                    TempData["Error"] = "Konu bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                var topics = await _topicService.GetMainTopicsAsync();
                ViewBag.ParentTopics = topics;
                return View(topic);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("Id,TopicName,ParentTopicId")] Topics topic)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var result = await _topicService.UpdateTopicAsync(id, topic.TopicName, topic.ParentTopicId);
                    if (result)
                    {
                        TempData["Success"] = "Konu başarıyla güncellendi.";
                        return RedirectToAction(nameof(Details), new { id = topic.Id });
                    }
                    else
                    {
                        TempData["Error"] = "Konu güncellenirken hata oluştu.";
                    }
                }

                var topics = await _topicService.GetMainTopicsAsync();
                ViewBag.ParentTopics = topics;
                return View(topic);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                var topics = await _topicService.GetMainTopicsAsync();
                ViewBag.ParentTopics = topics;
                return View(topic);
            }
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var topic = await _topicService.GetByIdAsync(id);
                if (topic == null)
                {
                    TempData["Error"] = "Konu bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                return View(topic);
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
                var result = await _topicService.DeleteTopicAsync(id);
                if (result)
                {
                    TempData["Success"] = "Konu başarıyla silindi.";
                }
                else
                {
                    TempData["Error"] = "Konu silinirken hata oluştu. Alt konuları veya soruları olan konular silinemez.";
                }

                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> Hierarchy()
        {
            try
            {
                var hierarchy = await _topicService.GetTopicHierarchyAsync();
                return View(hierarchy);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                return View(new List<Topics>());
            }
        }

        public async Task<IActionResult> MainTopics()
        {
            try
            {
                var mainTopics = await _topicService.GetMainTopicsAsync();
                return View(mainTopics);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                return View(new List<Topics>());
            }
        }

        public async Task<IActionResult> SubTopics(Guid id)
        {
            try
            {
                var subTopics = await _topicService.GetSubTopicsAsync(id);
                var parentTopic = await _topicService.GetByIdAsync(id);
                ViewBag.ParentTopic = parentTopic;
                return View(subTopics);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                return View(new List<Topics>());
            }
        }

        public async Task<IActionResult> WithSubTopics(Guid id)
        {
            try
            {
                var topic = await _topicService.GetTopicWithSubTopicsAsync(id);
                if (topic == null)
                {
                    TempData["Error"] = "Konu bulunamadı.";
                    return RedirectToAction(nameof(Index));
                }

                return View(topic);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                return RedirectToAction(nameof(Index));
            }
        }

        public async Task<IActionResult> QuestionCounts()
        {
            try
            {
                var counts = await _topicService.GetTopicQuestionCountsAsync();
                return View(counts);
            }
            catch (Exception ex)
            {
                TempData["Error"] = $"Hata oluştu: {ex.Message}";
                return View(new Dictionary<string, int>());
            }
        }
    }
} 