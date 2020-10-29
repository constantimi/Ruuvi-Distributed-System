﻿using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ruuvi.Dtos;
using Ruuvi.Models.Data;
using Ruuvi.Repository;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ruuvi.Controllers
{
    [Route("api/notifications")]
    public class NotificationController : Controller
    {
        private readonly IMongoDataRepository<Notification> _repository;
        private readonly IMapper _mapper;

        public NotificationController(IMongoDataRepository<Notification> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllNotifications()
        {
            var notifications = await _repository.GetAllLatestAsyc();

            if (notifications != null)
            {
                return Ok(_mapper.Map<IEnumerable<NotificationReadDto>>(notifications));
            }

            return NotFound();
        }

        [HttpGet("{id}", Name = "GetNotificationById")]
        public async Task<IActionResult> GetNotificationById(string id)
        {
            var notification = await _repository.GetObjectByIdAsync(id);

            if (notification != null)
            {
                return Ok(_mapper.Map<NotificationReadDto>(notification));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateNotification(NotificationCreateDto notificationCreateDto)
        {
            var notification = _mapper.Map<Notification>(notificationCreateDto);

            await _repository.CreateObjectAsync(notification);

            var notificationReadDto = _mapper.Map<NotificationReadDto>(notification);

            // https://docs.microsoft.com/en-us/dotnet/api/system.web.http.apicontroller.createdatroute?view=aspnetcore-2.2
            return CreatedAtRoute(nameof(GetNotificationById), new { Id = notificationReadDto.Id }, notificationReadDto);
        }
    }
}
