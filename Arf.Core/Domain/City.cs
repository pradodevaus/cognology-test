using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Arf.Core.Domain
{
    public class City
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }

        public virtual ICollection<Flight> ArrivalFlights { get; set; }
        public virtual ICollection<Flight> DepatureFlights { get; set; }
    }
}
