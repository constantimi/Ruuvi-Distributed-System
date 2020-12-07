using Ruuvi.Models.Core;
using Ruuvi.Models.Data;
using Ruuvi.Repository;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace Ruuvi.Controllers
{
    [Produces("application/json")]
    [Route("api/geometric/configurations")]
    [ApiController]
    public class GeometricController : ControllerBase
    {
        private readonly IMongoDataRepository<Route> _repositoryConstrain;
        private readonly IMongoDataRepository<RuuviStation> _repositoryRuuviStation;
        private readonly IMapper _mapper;

        public GeometricController(IMongoDataRepository<Route> repositoryConstrain, IMongoDataRepository<RuuviStation> repositoryRuuviStation, IMapper mapper)
        {
            this._repositoryConstrain = repositoryConstrain;
            this._repositoryRuuviStation = repositoryRuuviStation;
            _mapper = mapper;
        }
    }
}
