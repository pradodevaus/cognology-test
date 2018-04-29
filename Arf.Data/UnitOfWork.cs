using Arf.Core;
using Arf.Core.Domain;
using Arf.Core.Repositories;
using Arf.Data.Repositories;

namespace Arf.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ArfDbContext _dbContext;

        public IBookingRepository Bookings { get; private set; }
        public IFlightRepository Flights { get; private set; }
        public IRepository<City> Cities { get; private set; }

        public UnitOfWork(ArfDbContext dbContext)
        {
            _dbContext = dbContext;
            Bookings = new BookingRepository(_dbContext);
            Flights = new FlightRepository(_dbContext);
            Cities = new Repository<City>(_dbContext);
        }

        public int Save()
        {
            return _dbContext.SaveChanges();
        }

        public void Dispose()
        {
            _dbContext.Dispose();
        }
    }
}