using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arf.Services.Bookings
{
    public class PassengerInfoDto
    {
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public DateTime Dob { get; set; }
        public string Mobile { get; set; }
        public string Email { get; set; }
    }
}
