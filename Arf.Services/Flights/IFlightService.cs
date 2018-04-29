using Arf.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arf.Services.Flights
{
    public interface IFlightService
    {
        IEnumerable<Flight> GetFlights();

        IEnumerable<Flight> GetAvailableFlights(DateTime travelDate, int passengerCount, string depatureCityCode, string arrivalCityCode);
    }
}
