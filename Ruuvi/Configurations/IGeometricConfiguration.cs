using System.Collections.Generic;
using Ruuvi.Models.Core;

namespace Ruuvi.Configurations
{
    public interface IGeometricConfiguration
    {
        List<ServiceGeometric> IsBreached(string id);
    }
}
