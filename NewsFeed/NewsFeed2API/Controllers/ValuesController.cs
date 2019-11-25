using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace NewsFeed2API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        int i;
        private readonly NewsContext _context;
        public ValuesController(NewsContext context)
        {
            // i++;
             _context = context;
        }


        // GET api/values
        [HttpGet]
        public ActionResult<IEnumerable<News>> Get()
        {
            List<News> newsList = _context.news.ToList();
            return newsList;
        }

        // GET api/values/5
        [HttpGet("from/{startYear}/{startMonth}/to/{endYear}/{endMonth}")]
        public ActionResult<List<News>> Get(int startYear, int startMonth, int endYear, int endMonth)
        {
            DateTime dt1 = new DateTime(startYear, startMonth, 0);
            DateTime dt2 = new DateTime(endYear, endMonth, 0);


             List<News> newsList = _context.news.Where(x => x.CreatedDate >= dt1 && x.CreatedDate <= dt2).ToList();
            return newsList;
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {

            News news = new News()
            {
                NewsId = 800,
                Title = "Overskrift",
                Author = "Simon",
                Content = "Indhold",
                CreatedDate = DateTime.Now.AddDays(-1),
                UpdatedDate = DateTime.Now,
                HashTags = "#SimonErGud;#FedOpgave"
            };
            _context.Add(news);
            _context.SaveChanges();
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        { 
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
