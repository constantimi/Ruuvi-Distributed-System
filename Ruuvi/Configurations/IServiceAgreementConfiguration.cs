using System.Collections.Generic;
using Ruuvi.Models.Core;

namespace Ruuvi.Configurations
{
    public interface IServiceAgreementConfiguration
    {
        List<ServiceAgreement> IsBreached(string id);
    }
}
