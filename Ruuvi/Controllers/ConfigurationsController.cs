using System.Threading.Tasks;
using Ruuvi.Configurations;
using Ruuvi.Models.Data;
using Ruuvi.Repository;
using Ruuvi.Dtos;

using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;

namespace Ruuvi.Controllers
{
    [Produces("application/json")]
    [Route("api/configurations")]
    [ApiController]
    public class ConfigurationsController : ControllerBase
    {
        private readonly IMongoDataRepository<Constrain> _repositoryConstrain;
        private readonly IMongoDataRepository<RuuviStation> _repositoryRuuviStation;
        private readonly IMapper _mapper;

        public ConfigurationsController(IMongoDataRepository<Constrain> repositoryConstrain, IMongoDataRepository<RuuviStation> repositoryRuuviStation, IMapper mapper)
        {
            this._repositoryConstrain = repositoryConstrain;
            this._repositoryRuuviStation = repositoryRuuviStation;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetValadatedTagById(string id)
        {
            var constrain = await _repositoryConstrain.GetObjectByDeviceIdAsync(id);
            var station = await _repositoryRuuviStation.GetObjectByDeviceIdAsync(id);

            if (constrain != null && station != null)
            {
                var serviceAgreement = new ServiceAgreement(station.Tags.ToList(), constrain);;

                return Ok(_mapper.Map<IEnumerable<ConfigurationReadDto>>(serviceAgreement.IsBreached(station.DeviceId)));
            }

            return NotFound();
        }
    }
}
