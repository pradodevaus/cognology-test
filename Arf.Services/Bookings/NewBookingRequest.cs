using System;
using System.Collections.Generic;

namespace Arf.Services.Bookings
{
    public class NewBookingRequest
    {
        public string FlightNumber { get; set; }

        public DateTime TravelDate { get; set; }

        public IEnumerable<PassengerInfoDto> Passengers { get; set; }
    }
}