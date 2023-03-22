﻿using FirstAPIApp2.DTOs;
using FirstAPIApp2.DTOs.CreateUpdateObjects;
using FirstAPIApp2.DTOs.PatchObjects;
using FirstAPIApp2.Helpers;
using FirstAPIApp2.Models;
using FirstAPIApp2.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace FirstAPIApp2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AnnouncementsController : ControllerBase
    {
        private readonly IAnnouncementsService _announcementsService;
        private readonly ILogger<AnnouncementsController> _logger;

        public AnnouncementsController(IAnnouncementsService announcementsService, ILogger<AnnouncementsController> logger)
        {
            _announcementsService = announcementsService;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAnnouncementsAsync()
        {
            try
            {
                _logger.LogInformation("GetAnnouncements started");

                var announcements = await _announcementsService.GetAnnouncementsAsync();

                if (announcements == null || !announcements.Any())
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }

                return Ok(announcements);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAllAnnouncements error: {ex.Message}");
                return StatusCode((int)(HttpStatusCode.InternalServerError));
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAnnouncementAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("GetAccouncementById stareted");
                var announcement = await _announcementsService.GetAnnouncementByIdAsync(id);
                if (announcement == null)
                {
                    return NotFound(ErrorMessagesEnum.NoElementFound);
                }
                return Ok(announcement);
            }
            catch (Exception ex)
            {
                _logger.LogError($"GetAnnouncementById error: {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPost]
        public async Task<IActionResult> PostAnnouncementAsync([FromBody] Announcement announcement)
        {
            try
            {
                _logger.LogInformation("CreateAnnouncementAsync started.");
                if (announcement == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }
                await _announcementsService.CreateAnnouncementAsync(announcement);
                return Ok(SuccessMessagesEnum.ElementSuccessfullyAdded);

            }
            catch (ModelValidationException ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAnnouncementAsync([FromRoute] Guid id)
        {
            try
            {
                _logger.LogInformation("Delete Announcment Started");
                bool result = await _announcementsService.DeleteAnnouncementAsync(id);
                if (result)
                {
                    return Ok(SuccessMessagesEnum.ElementSuccessfullyDeleted);
                }
                return BadRequest(ErrorMessagesEnum.NoElementFound);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutAnnouncement([FromRoute] Guid id, [FromBody] CreateUpdateAnnouncement announcement)
        {
            try
            {
                _logger.LogInformation("Update started");
                if(announcement == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }

                CreateUpdateAnnouncement updatedAnnouncement = await _announcementsService.UpdateAnnouncementAsync(id, announcement);
                if (updatedAnnouncement == null)
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }
                return Ok(SuccessMessagesEnum.ElementSuccessfullyUpdated);

            }
            catch (ModelValidationException ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // patch should not use objects which are labled as required
        // there should be 3 separate objects: one for Get, one for CreateUpdate and one for Patch
        [HttpPatch("{id}")]
        public async Task<IActionResult> PatchAnnouncement([FromRoute] Guid id, [FromBody] PatchAnnouncement announcement)
        {
            try
            {
                _logger.LogInformation("Update started");
                if (announcement == null)
                {
                    return BadRequest(ErrorMessagesEnum.BadRequest);
                }

                PatchAnnouncement updatedAnnouncement = await _announcementsService.UpdatePartiallyAnnouncementAsync(id, announcement);
                if (updatedAnnouncement == null)
                {
                    return StatusCode((int)HttpStatusCode.NoContent, ErrorMessagesEnum.NoElementFound);
                }
                return Ok(SuccessMessagesEnum.ElementSuccessfullyUpdated);

            }
            catch (ModelValidationException ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return BadRequest(ex.Message);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Validation exception {ex.Message}");
                return StatusCode((int)HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
