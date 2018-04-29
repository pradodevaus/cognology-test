using Arf.Services.Flights;
using Arf.WebApi.Filters;
using Arf.WebApi.Models;
using Serilog;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Arf.WebApi.Controllers
{
    [RoutePrefix("api/v1/flights")]
    public class FlightController : ApiController
    {
        private readonly ILogger _log;
        private readonly IFlightService _flightService;

        public FlightController(IFlightService flightService)
        {
            _flightService = flightService;
            _log = Log.Logger.ForContext<FlightController>();
        }

        [Route("")]
        [HttpGet]
        public HttpResponseMessage GetFlights()
        {
            _log.Debug("Calling IFlightService.GetFlights()");

            var flights = _flightService.GetFlights()
                .Select(x => new FlightModel
                {
                    FlightNumber = x.FlightNumber,
                    Capacity = x.Capacity,
                    StartTime = x.StartTime.ToString("hh:mm"),
                    EndTime = x.EndTime.ToString("hh:mm"),
                    ArrivalCityCode = x.ArrivalCity.Code,
                    ArrivalCityName = x.ArrivalCity.Name,
                    DepartureCityCode = x.DepatureCity.Code,
                    DepartureCityName = x.DepatureCity.Name
                });

            _log.Debug($"Found {flights.Count()} flights");

            return Request.CreateResponse(HttpStatusCode.OK, flights);
        }

        [Route("search")]
        [HttpPost]
        [ValidateModel]
        public HttpResponseMessage CheckAvailability(FlightSearchModel model)
        {
            _log.Debug("Calling IFightService.GetAvailableFlights()");

            var flights = _flightService.GetAvailableFlights(DateTime.Parse(model.TravelDate), model.PassengerCount.Value, model.DepatureCityCode, model.ArrivalCityCode)
                .Select(x => new FlightModel
                {
                    FlightNumber = x.FlightNumber,
                    Capacity = x.Capacity,
                    StartTime = x.StartTime.ToString("hh:mm"),
                    EndTime = x.EndTime.ToString("hh:mm"),
                    ArrivalCityCode = x.ArrivalCity.Code,
                    ArrivalCityName = x.ArrivalCity.Name,
                    DepartureCityCode = x.DepatureCity.Code,
                    DepartureCityName = x.DepatureCity.Name
                });

            _log.Debug($"Found {flights.Count()} flights");

            if (flights.Count() == 0)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "No flights available");
            }

            return Request.CreateResponse(HttpStatusCode.OK, flights);
        }
    }
}