using Arf.Core.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arf.Services.Bookings
{
    public interface IBookingService
    {
        Booking GetBookingInfo(string lastname, DateTime travelDate, string flightNumber);

        void NewBooking(NewBookingRequest newBookingReq);
    }
}
