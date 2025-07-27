using AkademikAi.Entity.Entites;
using AkademikAi.Service.IServices;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace AkademikAi.Web.Controllers.Api
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserNotificationApiController : ControllerBase
    {
        private readonly IUserNotificationService _notificationService;

        public UserNotificationApiController(IUserNotificationService notificationService)
        {
            _notificationService = notificationService;
        }

        [HttpGet]
        public async Task<ActionResult<List<UserNotifications>>> GetAllNotifications()
        {
            try
            {
                var notifications = await _notificationService.GetAllAsync();
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserNotifications>> GetNotificationById(Guid id)
        {
            try
            {
                var notification = await _notificationService.GetByIdAsync(id);
                if (notification == null)
                    return NotFound();

                return Ok(notification);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}")]
        public async Task<ActionResult<List<UserNotifications>>> GetUserNotifications(Guid userId)
        {
            try
            {
                var notifications = await _notificationService.GetUserNotificationsAsync(userId);
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}/unread")]
        public async Task<ActionResult<List<UserNotifications>>> GetUnreadUserNotifications(Guid userId)
        {
            try
            {
                var notifications = await _notificationService.GetUnreadUserNotificationsAsync(userId);
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}/read")]
        public async Task<ActionResult<List<UserNotifications>>> GetReadUserNotifications(Guid userId)
        {
            try
            {
                var notifications = await _notificationService.GetReadUserNotificationsAsync(userId);
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}/count/unread")]
        public async Task<ActionResult<int>> GetUnreadNotificationCount(Guid userId)
        {
            try
            {
                var count = await _notificationService.GetUnreadNotificationCountAsync(userId);
                return Ok(count);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("user/{userId}/recent")]
        public async Task<ActionResult<List<UserNotifications>>> GetRecentUserNotifications(
            Guid userId, 
            [FromQuery] int count = 10)
        {
            try
            {
                var notifications = await _notificationService.GetRecentUserNotificationsAsync(userId, count);
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpGet("type/{notificationType}")]
        public async Task<ActionResult<List<UserNotifications>>> GetNotificationsByType(string notificationType)
        {
            try
            {
                var notifications = await _notificationService.GetNotificationsByTypeAsync(notificationType);
                return Ok(notifications);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<ActionResult<UserNotifications>> CreateNotification([FromBody] CreateNotificationDto createNotificationDto)
        {
            try
            {
                var notification = await _notificationService.CreateNotificationAsync(
                    createNotificationDto.UserId, 
                    createNotificationDto.Title, 
                    createNotificationDto.Message, 
                    createNotificationDto.NotificationType);

                return CreatedAtAction(nameof(GetNotificationById), new { id = notification.Id }, notification);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("bulk")]
        public async Task<ActionResult> CreateBulkNotifications([FromBody] CreateBulkNotificationDto createBulkNotificationDto)
        {
            try
            {
                var result = await _notificationService.CreateBulkNotificationsAsync(
                    createBulkNotificationDto.UserIds, 
                    createBulkNotificationDto.Title, 
                    createBulkNotificationDto.Message, 
                    createBulkNotificationDto.NotificationType);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> UpdateNotification(Guid id, [FromBody] UpdateNotificationDto updateNotificationDto)
        {
            try
            {
                var result = await _notificationService.UpdateNotificationAsync(
                    id, 
                    updateNotificationDto.Title, 
                    updateNotificationDto.Message);

                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("{id}/mark-as-read")]
        public async Task<ActionResult> MarkNotificationAsRead(Guid id)
        {
            try
            {
                var result = await _notificationService.MarkNotificationAsReadAsync(id);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpPost("user/{userId}/mark-all-as-read")]
        public async Task<ActionResult> MarkAllUserNotificationsAsRead(Guid userId)
        {
            try
            {
                var result = await _notificationService.MarkAllUserNotificationsAsReadAsync(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteNotification(Guid id)
        {
            try
            {
                var result = await _notificationService.DeleteNotificationAsync(id);
                if (!result)
                    return NotFound();

                return NoContent();
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }

        [HttpDelete("user/{userId}")]
        public async Task<ActionResult> DeleteAllUserNotifications(Guid userId)
        {
            try
            {
                var result = await _notificationService.DeleteAllUserNotificationsAsync(userId);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }

    public class CreateNotificationDto
    {
        public Guid UserId { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string NotificationType { get; set; }
    }

    public class CreateBulkNotificationDto
    {
        public List<Guid> UserIds { get; set; }
        public string Title { get; set; }
        public string Message { get; set; }
        public string NotificationType { get; set; }
    }

    public class UpdateNotificationDto
    {
        public string Title { get; set; }
        public string Message { get; set; }
    }
} 