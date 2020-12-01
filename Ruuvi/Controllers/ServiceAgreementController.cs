using System.Collections.Generic;
using System.Threading.Tasks;
using Ruuvi.Configurations;
using Ruuvi.Dtos;
using Ruuvi.Models.Core;
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
        private readonly IConstrainDataRepository<Agreement> _repositoryConstrain;
        private readonly IMongoDataRepository<RuuviStation> _repositoryRuuviStation;
        private readonly IMapper _mapper;

        public ServiceAgreementController(IConstrainDataRepository<Agreement> repositoryConstrain, IMongoDataRepository<RuuviStation> repositoryRuuviStation, IMapper mapper)
        {
            this._repositoryConstrain = repositoryConstrain;
            this._repositoryRuuviStation = repositoryRuuviStation;
            _mapper = mapper;
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetValadatedDeviceById(string id)
        {
            var constrain = await _repositoryConstrain.GetObjectByDeviceIdAsync(id);
            var station = await _repositoryRuuviStation.GetObjectByDeviceIdAsync(id);

            if (constrain != null && station != null)
            {
                var serviceAgreement = new ServiceAgreementConfiguration(station.Tags, constrain);

                return Ok(_mapper.Map<IEnumerable<ServiceConfigurationReadDto>>(serviceAgreement.IsBreached(station.DeviceId)));
            }

            return NotFound();
        }
    }
}
