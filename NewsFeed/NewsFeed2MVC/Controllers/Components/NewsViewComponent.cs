using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using NewsFeed2MVC.Models;

namespace NewsFeed2MVC.Controllers.Components
{
    [ViewComponent(Name = "NewsComponent")]
    public class NewsViewComponent : ViewComponent
    {
        public NewsViewComponent()
        {
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync("https://localhost:44325/api/values").Result;
                response.EnsureSuccessStatusCode();
                var responseBody = response.Content.ReadAsStringAsync().Result;
                var model = JsonConvert.DeserializeObject<List<News>>(responseBody);
                return View(model);
            }
        }
    }
}
