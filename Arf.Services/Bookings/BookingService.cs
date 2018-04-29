using System;
using System.Collections.Generic;
using Arf.Core;
using Arf.Core.Domain;
using Serilog;
using System.Linq;

namespace Arf.Services.Bookings
{
    public class BookingService : IBookingService
    {
        private readonly IUnitOfWork _uow;
        private readonly ILogger _log;

        public BookingService(IUnitOfWork uow)
        {
            _uow = uow;
            _log = Log.Logger.ForContext<BookingService>();
        }

        public Booking GetBookingInfo(string lastname, DateTime travelDate, string flightNumber)
        {
            _log.Debug($"Executing IBookingService.BookingService({lastname},{travelDate},{flightNumber})");

            if (string.IsNullOrWhiteSpace(lastname))
                throw new ArgumentNullException(nameof(lastname));

            if (travelDate.Date == DateTime.MinValue.Date)
                throw new ArgumentNullException(nameof(travelDate));

            if (string.IsNullOrWhiteSpace(flightNumber))
                throw new ArgumentNullException(nameof(flightNumber));

            return _uow.Bookings.GetBooking(lastname, travelDate, flightNumber);
        }

        public void NewBooking(NewBookingRequest newBookingReq)
        {
            if(newBookingReq == null)
                throw new ArgumentNullException(nameof(newBookingReq));

            if(newBookingReq.TravelDate.Date < DateTime.Now.Date)
            {
                throw new ArgumentException("TravelDate must be present or future date");
            }

            var flight = _uow.Flights
                .SingleOrDefault(x => x.FlightNumber.Equals(newBookingReq.FlightNumber, StringComparison.InvariantCultureIgnoreCase));

            if(flight == null)
            {
                throw new ArgumentException($"FlightNumber: {newBookingReq.FlightNumber} is invalid");
            }

            var newBooking = new Booking
            {
                FlightNumber = flight.FlightNumber,
                FlightId = flight.Id,
                TotalAmount = 200,
                TravelDate = newBookingReq.TravelDate.Date,
                Status = "CONFIRMED",
                PassengerCount = newBookingReq.Passengers.Count(),
                Passengers = newBookingReq.Passengers
                                            .Select(x => new Passenger
                                            {
                                                Firstname = x.Firstname,
                                                Lastname = x.Lastname,
                                                Mobile = x.Mobile,
                                                Dob = x.Dob,
                                                Email = x.Email,
                                                CreatedOn = DateTime.Now,
                                                UpdatedOn = DateTime.Now
                                            })
                                            .ToList(),
                CreatedOn = DateTime.Now,
                UpdatedOn = DateTime.Now
            };

            _uow.Bookings.Add(newBooking);

            _uow.Save();

            _log.Debug($"Booking created with BookingId {newBooking.Id}");
        }
    }
}