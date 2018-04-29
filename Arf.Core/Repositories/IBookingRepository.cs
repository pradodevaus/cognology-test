using Arf.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arf.Core.Repositories
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Booking GetBooking(string lastname, DateTime travelDate, string flightNumber);
    }
}
