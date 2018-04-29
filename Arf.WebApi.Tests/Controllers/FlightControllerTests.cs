using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using Arf.Services.Flights;
using Arf.WebApi.Controllers;
using System.Collections.Generic;
using Arf.Core.Domain;
using Arf.WebApi.Models;
using System.Net.Http;
using System.Web.Http;
using System.Linq;

namespace Arf.WebApi.Tests.Controllers
{
    [TestClass]
    public class FlightControllerTests
    {
        [TestMethod]
        public void GetFlights_ShouldFetchFlightDetails()
        {
            //ARRANGE
            var mockFlightService = new Mock<IFlightService>();
            mockFlightService
                .Setup(x => x.GetFlights())
                .Returns(new List<Flight>
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

            var controller = new FlightController(mockFlightService.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //ACT
            var response = controller.GetFlights();

            //ASSERT
            mockFlightService.Verify(x => x.GetFlights(),Times.Once);

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.OK);

            IEnumerable<FlightModel> flights;
            Assert.IsTrue(response.TryGetContentValue<IEnumerable<FlightModel>>(out flights));

            Assert.IsTrue(flights.Count() == 1);
        }

        [TestMethod]
        public void CheckAvailability_WhenServiceReturnsEmptyList_ThenSendNotFoundResponse()
        {
            //ARRANGE
            var mockFlightService = new Mock<IFlightService>();
            mockFlightService
                .Setup(x => x.GetAvailableFlights(It.IsAny<DateTime>(), It.IsAny<int>(), It.IsAny<string>(), It.IsAny<string>()))
                .Returns(new List<Flight>{});

            var controller = new FlightController(mockFlightService.Object);
            controller.Request = new HttpRequestMessage();
            controller.Configuration = new HttpConfiguration();

            //ACT
            var flightSearchModel = new FlightSearchModel
            {
                PassengerCount = 1,
                ArrivalCityCode = "MEL",
                DepatureCityCode = "PER",
                TravelDate = "30/04/2018"
            };

            var response = controller.CheckAvailability(flightSearchModel);

            //ASSERT
            mockFlightService.Verify(x => x.GetAvailableFlights(
                It.Is<DateTime>(y => y.Date == DateTime.Parse(flightSearchModel.TravelDate).Date),
                It.Is<int>(y => y == flightSearchModel.PassengerCount),
                It.Is<string>(y => y == flightSearchModel.DepatureCityCode),
                It.Is<string>(y => y == flightSearchModel.ArrivalCityCode))
                , Times.Once);

            Assert.IsTrue(response.StatusCode == System.Net.HttpStatusCode.NotFound);
        }
    }
}
