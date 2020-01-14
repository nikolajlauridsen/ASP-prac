using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.AspNetCore.Mvc;

using GaveBodAPI.Models;

namespace GaveBodAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class Gifts : ControllerBase
    {
        private static List<Gift> gifts = new List<Gift>();
        private static object GiftLock = new object();

        public Gifts()
        {
            if(gifts.Count == 0)
            {
                gifts.Add(new Gift
                {
                    GiftNumber = 1,
                    CreationDate = DateTime.Now,
                    Title = "Xbox One",
                    Description = "En spillekonsol",
                    BoyGift = true,
                    GirlGift = true
                });

                gifts.Add(new Gift
                {
                    GiftNumber = 2,
                    CreationDate = DateTime.Now,
                    Title = "PS4 Pro",
                    Description = "En spillekonsol",
                    BoyGift = true,
                    GirlGift = true
                });
                gifts.Add(new Gift()
                {
                    GiftNumber = 3,
                    CreationDate = new DateTime(2019, 12, 1),
                    Title = "Old Gift",
                    Description = "This is an old gift",
                    BoyGift = true,
                    GirlGift = true
                });
            }
        }

        [HttpGet]
        public IEnumerable<Gift> Get()
        {
            return gifts;
        }

        [HttpGet("{GiftNumber}")]
        public Gift Get(int GiftNumber)
        {
            Gift gift = gifts.First(g => g.GiftNumber == GiftNumber);
            return gift;
        }

        [HttpPost]
        public ActionResult PostGift([Bind("Title", "Description", "BoyGift", "GirlGift")] Gift gift)
        {
            lock (GiftLock)
            {
                gift.GiftNumber = gifts.Last().GiftNumber + 1;
                gift.CreationDate = DateTime.Now;
                gifts.Add(gift);
            }
            
            return CreatedAtAction("Get", new { GiftNumber = gift.GiftNumber }, gift);
        }

        [HttpDelete("{id}")]
        public ActionResult DeleteGift(int id)
        {
            Gift gift = gifts.First(g => g.GiftNumber == id);
            gifts.Remove(gift);
            return StatusCode(200);
        }
    }
}
