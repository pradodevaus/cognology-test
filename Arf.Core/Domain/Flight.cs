using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arf.Core.Domain
{
    public class Flight
    {
        public int Id { get; set; }
        public string FlightNumber { get; set; }
        public int Capacity { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }
        public int DepatureCityId { get; set; }
        public int ArrivalCityId { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual City DepatureCity { get; set; }
        public virtual City ArrivalCity { get; set; }

        public virtual ICollection<Booking> Bookings { get; set; }

        public Flight()
        {
            Bookings = new HashSet<Booking>();
        }
    }
}
