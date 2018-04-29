using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arf.WebApi.Models
{
    public class BookingSearchResult
    {
        public DateTime TravelDate { get; set; }
        public FlightModel FlightDetails { get; set; }
        public IEnumerable<PassengerModel> Passengers { get; set; }
        public decimal TotalAmount { get; set; }
        public DateTime BookingDate { get; set; }
        public string Status { get; set; }
    }
}