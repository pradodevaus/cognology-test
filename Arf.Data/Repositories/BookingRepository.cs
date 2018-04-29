using Arf.Core.Domain;
using Arf.Core.Repositories;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Arf.Data.Repositories
{
    public class BookingRepository : Repository<Booking>, IBookingRepository
    {
        public BookingRepository(ArfDbContext dbContext) : base(dbContext)
        {
        }

        public Booking GetBooking(string lastname, DateTime travelDate, string flightNumber)
        {
            var booking = DbContext.Bookings
                .Include(x => x.Passengers)
                .Include(x => x.Flight)
                .SingleOrDefault(x => x.TravelDate == travelDate
                        && x.FlightNumber == flightNumber
                        && x.Passengers.Any(y => y.Lastname.Equals(lastname, StringComparison.InvariantCultureIgnoreCase)));

            return booking;
        }
    }
}