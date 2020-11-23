using System.Collections.Generic;
using Ruuvi.Models.Data;

namespace Ruuvi.Configuration
{
    public interface IServiceAgreement
    {
        List<Dictionary<string, bool>> Check();

        bool Breached(Tag tag);
    }
}
