using Arf.Core;
using Arf.Core.Domain;
using Arf.Core.Repositories;
using Arf.Services.Flights;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Arf.Services.Tests
{
    [TestClass]
    public class FlightServiceTests
    {
        [TestMethod]
        public void GetFlights_ShouldCallCorrectRepositoryMethod()
        {
            //ARRANGE
            var mockUow = new Mock<IUnitOfWork>();

            var mockFlightRepository = new Mock<IFlightRepository>();
            mockFlightRepository.Setup(x => x.GetAllFlightsWithCities()).Returns(new List<Flight>
            {
                new Flight
                {
                    FlightNumber = "ARF001",
                    Id = 1,
                    Capacity=5,
                    ArrivalCity = new City { Code="MEL", Name="Melbourne" },
                    DepatureCity = new City { Code="PER", Name="Perth" },
                    EndTime = DateTime.Now,
                    StartTime = DateTime.Now,
                }
            });

            mockUow.Setup(x => x.Flights).Returns(mockFlightRepository.Object);

            var flightService = new FlightService(mockUow.Object);

            //ACT
            var flights = flightService.GetFlights();

            //ASSERT
            mockFlightRepository.Verify(x => x.GetAllFlightsWithCities(), Times.Once);

            Assert.IsTrue(flights.Count() == 1);
        }
    }
}