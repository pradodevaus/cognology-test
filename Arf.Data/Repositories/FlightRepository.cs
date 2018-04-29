using Arf.Core.Domain;
using Arf.Core.Repositories;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Arf.Data.Repositories
{
    public class FlightRepository : Repository<Flight>, IFlightRepository
    {
        public FlightRepository(ArfDbContext dbContext) : base(dbContext)
        {
        }

        public IEnumerable<Flight> GetAllFlightsWithCities()
        {
            return DbContext.Flights
                .Include(x => x.ArrivalCity)
                .Include(x => x.DepatureCity)
                .ToList();
        }
    }
}