using System.Collections.Generic;
using Ruuvi.Models.Data;

namespace Ruuvi.Configurations
{
    public interface IServiceAgreement
    {
        List<Configuration> IsBreached(string id);

    }
}
