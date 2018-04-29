using Arf.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arf.Core.Repositories
{
    public interface IFlightRepository : IRepository<Flight>
    {
        IEnumerable<Flight> GetAllFlightsWithCities();
    }
}
