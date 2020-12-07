using System.Threading.Tasks;
using Ruuvi.Hubs.Clients;
using Ruuvi.Models.Data;
using Microsoft.AspNetCore.SignalR;

namespace Ruuvi.Hubs
{
    public class RuuviStationHub : Hub<IRuuviStationClient>
    {
        public async Task SendRuuviStation(RuuviStation station)
        {
            await Clients.All.ReceiveRuuviStation(station);
        }
    }
}
