using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Ruuvi.Models.Core;
using AutoMapper.Configuration;

namespace Ruuvi.Configurations
{
    public class GeometricConfiguration : IConfiguration<Route>
    {
        public Task<List<Route>> IsBreached()
        {
            throw new NotImplementedException();
        }
    }
}
