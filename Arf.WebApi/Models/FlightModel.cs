using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arf.WebApi.Models
{
    public class FlightModel
    {
        public string FlightNumber { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int Capacity { get; set; }
        public string ArrivalCityCode { get; set; }
        public string ArrivalCityName { get; set; }
        public string DepartureCityCode { get; set; }
        public string DepartureCityName { get; set; }
    }
}