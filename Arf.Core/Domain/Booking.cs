using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arf.Core.Domain
{
    public class Booking
    {
        public int Id { get; set; }
        public int FlightId { get; set; }
        public string FlightNumber { get; set; }
        public DateTime TravelDate { get; set; }
        public decimal TotalAmount { get; set; }
        public string Status { get; set; }
        public int PassengerCount { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual ICollection<Passenger> Passengers { get; set; }
        public virtual Flight Flight { get; set; }

        public Booking()
        {
            Passengers = new HashSet<Passenger>();
        }
    }
}
