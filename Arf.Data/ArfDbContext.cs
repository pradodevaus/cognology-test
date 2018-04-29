using Arf.Core.Domain;
using Arf.Data.Conventions;
using Arf.Data.EntityConfigurations;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arf.Data
{
    public class ArfDbContext : DbContext
    {
        public ArfDbContext()
            : base("name=ArfDbConnection")
        {
            //this.Configuration.LazyLoadingEnabled = false;
            Database.SetInitializer<ArfDbContext>(null);
        }

        public virtual IDbSet<Passenger> Passengers { get; set; }
        public virtual IDbSet<City> Cities { get; set; }
        public virtual IDbSet<Flight> Flights { get; set; }
        public virtual IDbSet<Booking> Bookings { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Entity Configurations
            modelBuilder.Configurations.Add(new CityConfiguration());
            modelBuilder.Configurations.Add(new PassengerConfiguration());
            modelBuilder.Configurations.Add(new FlightConfiguration());
            modelBuilder.Configurations.Add(new BookingConfiguration());

            //Custom Conventions
            modelBuilder.Conventions.Add(new DateTime2Convention());
        }
    }
}
