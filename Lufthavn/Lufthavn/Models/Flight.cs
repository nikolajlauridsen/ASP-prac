using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Lufthavn.Models
{
    public class Flight
    {
        [Key]
        public int FlightId { get; set; }

        [Display(Name = "Aircraft type")]
        public string AircraftType { get; set; }

        [Display(Name = "From location")]
        public string FromLocation { get; set; }

        [Display(Name = "To location")]
        public string ToLocation { get; set; }

        [Display(Name ="Depature time"), DisplayFormat(DataFormatString = "{0:MM/dd/yyy HH:ss}")]
        public DateTime DepartureTime { get; set; }

        [Display(Name = "Arrival time"), DisplayFormat(DataFormatString = "{0:MM/dd/yyy HH:ss}")]
        public DateTime ArrivalTime { get; set; }
    }
}
