﻿using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Ruuvi.Configurations;
using Ruuvi.Dtos.Core;
using Ruuvi.Models.Core.ServiceAgreement;
using Ruuvi.Models.Data;
using Ruuvi.Repository;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ruuvi.Controllers
{
    [Produces("application/json")]
    [Route("api/agreement/configurations")]
    [ApiController]
    public class ServiceAgreementController : ControllerBase
    {
        private readonly IMongoDataRepository<Agreement> _repositoryConstrain;
        private readonly IMongoDataRepository<RuuviStation> _repositoryRuuviStation;
        private readonly IMapper _mapper;

        public ServiceAgreementController(IMongoDataRepository<Agreement> repositoryConstrain, IMongoDataRepository<RuuviStation> repositoryRuuviStation, IMapper mapper)
        {
            this._repositoryRuuviStation = repositoryRuuviStation;
            this._repositoryConstrain = repositoryConstrain;
            _mapper = mapper;
        }

        private async Task<List<RuuviStation>> GetAllObjectsAsync()
        {
            var stations = await _repositoryRuuviStation.GetAllAsync();
            return stations.GroupBy(doc => new { doc.DeviceId }, (key, group) => group.First()).ToList();
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetValadatedDeviceById(string id)
        {
            var stations = await GetAllObjectsAsync();
            var station = stations.Find(doc => doc.DeviceId == id);

            if (station != null)
            {
                var serviceAgreement = new ServiceAgreementConfiguration(station, _repositoryConstrain);

                var breachedStations = await serviceAgreement.IsBreached();
                return Ok(_mapper.Map<IEnumerable<ServiceAgreementReadDto>>(breachedStations));
            }

            return NotFound();
        }
    }
}
