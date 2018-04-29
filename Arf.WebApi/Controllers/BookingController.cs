using Arf.Services.Bookings;
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
    [RoutePrefix("api/v1/bookings")]
    public class BookingController : ApiController
    {
        private readonly ILogger _log;
        private readonly IBookingService _bookingService;

        public BookingController(IBookingService bookingService)
        {
            _bookingService = bookingService;
            _log = Log.Logger.ForContext<BookingController>();
        }

        [Route("search")]
        [HttpPost]
        [ValidateModel]
        public HttpResponseMessage SearchBooking(BookingSearchModel model)
        {
            _log.Debug("Calling IBookingService.GetBookingInfo()");

            var booking = _bookingService
                .GetBookingInfo(model.Lastname, DateTime.Parse(model.TravelDate), model.FlightNumber);

            if (booking == null)
            {
                return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Booking not found");
            }

            var bookingSearchResult = new BookingSearchResult
            {
                TravelDate = booking.TravelDate,
                TotalAmount = booking.TotalAmount,
                BookingDate = booking.UpdatedOn,
                Status = booking.Status,
                FlightDetails = new FlightModel
                {
                    FlightNumber = booking.FlightNumber,
                    Capacity = booking.Flight.Capacity,
                    StartTime = booking.Flight.StartTime.ToString("hh:mm"),
                    EndTime = booking.Flight.EndTime.ToString("hh:mm"),
                    ArrivalCityCode = booking.Flight.ArrivalCity.Code,
                    ArrivalCityName = booking.Flight.ArrivalCity.Name,
                    DepartureCityCode = booking.Flight.DepatureCity.Code,
                    DepartureCityName = booking.Flight.DepatureCity.Name
                },
                Passengers = booking.Passengers.Select(y => new PassengerModel
                {
                    Firstname = y.Firstname,
                    Lastname = y.Lastname,
                    Dob = y.Dob.ToString("dd/MM/yyyy")
                })
            };

            return Request.CreateResponse(HttpStatusCode.OK, bookingSearchResult);
        }

        [Route("new")]
        [HttpPost]
        [ValidateModel]
        public HttpResponseMessage AddBookings(NewBookingModel model)
        {
            _log.Debug("Calling IBookingService.NewBooking()");

            var newBookingReq = new NewBookingRequest
            {
                FlightNumber = model.FlightNumber,
                TravelDate = DateTime.Parse(model.TravelDate).Date,
                Passengers = model.Passengers.Select(x => new PassengerInfoDto
                {
                    Firstname = x.Firstname,
                    Lastname = x.Lastname,
                    Dob = DateTime.Parse(x.Dob).Date,
                    Mobile = x.Mobile,
                    Email = x.Email
                })
            };

            try
            {
                _bookingService.NewBooking(newBookingReq);
            }
            catch (ArgumentException ex)
            {
                return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.Created, "Your booking is created sucessfully");
        }
    }
}