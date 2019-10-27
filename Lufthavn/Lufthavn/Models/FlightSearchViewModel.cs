using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lufthavn.Models
{
    public class FlightSearchViewModel
    {
        public List<Flight> Flights { get; set; }
        public string ToString { get; set; }
        public  string FromString { get; set; }
    }
}
