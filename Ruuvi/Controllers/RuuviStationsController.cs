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
    [Produces("application/json")]
    [Route("api/stations/")]
    [ApiController]
    public class RuuviStationsController : ControllerBase
    {
        private readonly IMongoDataRepository<RuuviStation> _repository;
        private readonly IMapper _mapper;

        public RuuviStationsController(IMongoDataRepository<RuuviStation> repository, IMapper mapper)
        {
            _mapper = mapper;
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllRuuviStations()
        {
            var stations = await _repository.GetAllLatestAsync();

            if (stations != null)
            {
                return Ok(_mapper.Map<IEnumerable<RuuviStationReadDto>>(stations));
            }

            return NotFound();
        }

        [HttpGet("{id}", Name="GetRuuviStationByDeviceId")]
        public async Task<IActionResult> GetRuuviStationByDeviceId(string id)
        {
            var station = await _repository.GetObjectByDeviceIdAsync(id);

            if (station != null)
            {
                return Ok(_mapper.Map<RuuviStationReadDto>(station));
            }

            return NotFound();
        }

        [HttpGet("all/{id}", Name = "GetAllByDeviceId")]
        public async Task<IActionResult> GetAllByDeviceId(string id)
        {
            var stations = await _repository.GetAllObjectsByDeviceIdAsync(id);

            if (stations != null)
            {
                return Ok(_mapper.Map<List<RuuviStationReadDto>>(stations));
            }

            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> CreateRuuviStation(RuuviStationCreateDto ruuviStationCreateDto)
        {
            var station = _mapper.Map<RuuviStation>(ruuviStationCreateDto);

            await _repository.CreateObjectAsync(station);

            var ruuviStationReadDto = _mapper.Map<RuuviStationReadDto>(station);

            // https://docs.microsoft.com/en-us/dotnet/api/system.web.http.apicontroller.createdatroute?view=aspnetcore-2.2
            return CreatedAtRoute(nameof(GetRuuviStationByDeviceId), new { Id = ruuviStationReadDto.Id }, ruuviStationReadDto);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateRuuviStation(string id, RuuviStationCreateDto stationCreateDto)
        {
            var stationModel = _mapper.Map<RuuviStation>(stationCreateDto);
            var station = await _repository.GetObjectByIdAsync(id);

            if (station != null)
            {
                stationModel.UpdatedAt = DateTime.UtcNow;
                stationModel.Id = new MongoDB.Bson.ObjectId(id);
                _repository.UpdateObject(id, stationModel);
                return Ok(_mapper.Map<RuuviStationReadDto>(stationModel));
            }

            return NotFound();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteRuuviStation(string id)
        {
            var stationModel = await _repository.GetObjectByIdAsync(id);

            if (stationModel != null)
            {
                await _repository.RemoveObjectAsync(stationModel);
                return Ok("Successfully deleted from collection!");
            }

            return NotFound();
        }
    }
}
