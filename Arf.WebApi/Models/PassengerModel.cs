using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Arf.WebApi.Models
{
    public class PassengerModel
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Dob { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}