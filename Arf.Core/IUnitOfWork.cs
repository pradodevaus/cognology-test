using Arf.Core.Domain;
using Arf.Core.Repositories;
using System;

namespace Arf.Core
{
    public interface IUnitOfWork : IDisposable
    {
        IBookingRepository Bookings { get; }
        IFlightRepository Flights { get; }
        IRepository<City> Cities { get; }

        int Save();
    }
}