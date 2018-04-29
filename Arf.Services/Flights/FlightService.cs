using Arf.Core;
using Arf.Core.Domain;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Arf.Services.Flights
{
    public class FlightService : IFlightService
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger _log;

        public FlightService(IUnitOfWork uow)
        {
            _uow = uow;
            _log = Log.Logger.ForContext<FlightService>();
        }

        public IEnumerable<Flight> GetFlights()
        {
            return _uow.Flights.GetAllFlightsWithCities();
        }

        public IEnumerable<Flight> GetAvailableFlights(DateTime travelDate, int passengerCount, string depatureCityCode, string arrivalCityCode)
        {
            if (travelDate.Date == DateTime.MinValue.Date)
                throw new ArgumentNullException(nameof(travelDate));

            if (passengerCount < 1)
                throw new ArgumentNullException(nameof(passengerCount));

            if (string.IsNullOrWhiteSpace(arrivalCityCode))
                throw new ArgumentNullException(nameof(arrivalCityCode));

            if (string.IsNullOrWhiteSpace(depatureCityCode))
                throw new ArgumentNullException(nameof(depatureCityCode));

            var arrivalCity = _uow.Cities.SingleOrDefault(x => x.Code.Equals(arrivalCityCode, StringComparison.InvariantCultureIgnoreCase));

            if (arrivalCity == null)
                throw new ArgumentException($"City with code {nameof(arrivalCityCode)} not found");

            var depatureCity = _uow.Cities.SingleOrDefault(x => x.Code.Equals(depatureCityCode, StringComparison.InvariantCultureIgnoreCase));

            if (depatureCity == null)
                throw new ArgumentException($"City with code {nameof(depatureCityCode)} not found");

            var flights = _uow.Flights
                .Find(x => x.DepatureCityId == depatureCity.Id
                    && x.ArrivalCityId == arrivalCity.Id
                    && x.Capacity >= passengerCount);

            var bookings = _uow.Bookings.Find(x => x.TravelDate == travelDate
                                && flights.Any(y => y.Id == x.FlightId));

            flights = flights
                .Where(x => bookings.Any(y => (y.PassengerCount + passengerCount) <= x.Capacity))
                .ToList();

            return flights;
        }
    }
}