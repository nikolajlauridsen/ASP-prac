using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace GaveBodAPI.Models
{
    public class Gift
    {
        public int GiftNumber { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public bool BoyGift { get; set; }

        public bool GirlGift { get; set; }
    }
}
