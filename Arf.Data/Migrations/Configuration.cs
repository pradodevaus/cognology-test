namespace Arf.Data.Migrations
{
    using Core.Domain;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<Arf.Data.ArfDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(Arf.Data.ArfDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.

            context.Cities.AddOrUpdate(new City { Id = 1, Name = "Sydney", Code = "SYD", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now });
            context.Cities.AddOrUpdate(new City { Id = 2, Name = "Melbourne", Code = "MEL", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now });
            context.Cities.AddOrUpdate(new City { Id = 3, Name = "Perth", Code = "PER", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now });
            context.Cities.AddOrUpdate(new City { Id = 4, Name = "Brisbane", Code = "BNE", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now });
            context.Cities.AddOrUpdate(new City { Id = 5, Name = "Adelaide", Code = "ADL", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now });
            context.Cities.AddOrUpdate(new City { Id = 6, Name = "Canberra", Code = "CBR", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now });
            context.Cities.AddOrUpdate(new City { Id = 7, Name = "Gold Coast", Code = "OOL", CreatedOn = DateTime.Now, UpdatedOn = DateTime.Now });

            context.Flights.AddOrUpdate(
                new Flight
                {
                    Id = 1,
                    FlightNumber = "ARF01",
                    Capacity = 5,
                    StartTime = Convert.ToDateTime("0001-01-01 02:00:00"),
                    EndTime = Convert.ToDateTime("0001-01-01 05:00:00"),
                    DepatureCityId = 1,
                    ArrivalCityId = 2,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                });

            context.Flights.AddOrUpdate(
                new Flight
                {
                    Id = 2,
                    FlightNumber = "ARF02",
                    Capacity = 3,
                    StartTime = Convert.ToDateTime("0001-01-01 04:00:00"),
                    EndTime = Convert.ToDateTime("0001-01-01 08:00:00"),
                    DepatureCityId = 5,
                    ArrivalCityId = 6,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                });

            context.Flights.AddOrUpdate(
                new Flight
                {
                    Id = 3,
                    FlightNumber = "ARF03",
                    Capacity = 10,
                    StartTime = Convert.ToDateTime("0001-01-01 04:00:00"),
                    EndTime = Convert.ToDateTime("0001-01-01 08:00:00"),
                    DepatureCityId = 3,
                    ArrivalCityId = 4,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now
                });

            context.Bookings.AddOrUpdate(
                new Booking
                {
                    Id = 1,
                    FlightId = 1,
                    FlightNumber = "ARF01",
                    Status = "CONFIRMED",
                    TotalAmount = 100.00m,
                    TravelDate = DateTime.Now.AddDays(1).Date,
                    PassengerCount = 2,
                    CreatedOn = DateTime.Now,
                    UpdatedOn = DateTime.Now,
                    Passengers = new List<Passenger>
                    {
                        new Passenger
                        {
                            Firstname = "John",
                            Lastname = "Doe",
                            Mobile = "0444444444",
                            Email = "jd@test.com",
                            Dob = DateTime.Now.AddYears(-30).Date,
                            CreatedOn = DateTime.Now,
                            UpdatedOn = DateTime.Now,
                            BookingId = 1
                        },
                        new Passenger
                        {
                            Firstname = "Hugh",
                            Lastname = "Jackman",
                            Mobile = "0444444444",
                            Email = "hj@test.com",
                            Dob = DateTime.Now.AddYears(-35).Date,
                            CreatedOn = DateTime.Now,
                            UpdatedOn = DateTime.Now,
                            BookingId = 1
                        }
                    }
                });
        }
    }
}