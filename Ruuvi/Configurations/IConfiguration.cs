using System.Collections.Generic;
using System.Threading.Tasks;
using Ruuvi.Models.Core;

namespace Ruuvi.Configurations
{
    public interface IConfiguration<TConfiguration>
    {
        Task<List<TConfiguration>> IsBreached();
    }
}
