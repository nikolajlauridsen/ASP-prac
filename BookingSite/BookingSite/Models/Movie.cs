using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BookingSite.Models
{
    public class Movie
    {
        [JsonProperty("id")]
        public long ID { get; set; }

        [JsonProperty("title")]
        public string Title { get; set; }

        [JsonProperty("genre")]
        public string Genre { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("numSeats")]
        public long NumSeats { get; set; }
    }
}
