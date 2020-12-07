using System.Threading.Tasks;
using Ruuvi.Models.Data;

namespace Ruuvi.Hubs.Clients
{
    public interface IRuuviStationClient
    {
        Task ReceiveRuuviStation(RuuviStation station);
    }
}
