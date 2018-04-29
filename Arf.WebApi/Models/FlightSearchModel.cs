using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Arf.WebApi.Models
{
    public class FlightSearchModel
    {
        [Required]
        [RegularExpression("(0[1-9]|[12][0-9]|3[01])[-/](0[1-9]|1[012])[-/](20)\\d\\d", ErrorMessage = "Date must be in dd/MM/yyyy format")]
        public string TravelDate { get; set; }

        [Required]
        [Range(1,10)]
        public int? PassengerCount { get; set; }

        [Required]
        public string DepatureCityCode { get; set; }

        [Required]
        public string ArrivalCityCode { get; set; }
    }
}