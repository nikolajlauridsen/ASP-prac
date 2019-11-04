using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Net;
using BookingSite.Models;
using Newtonsoft.Json;
using System.Net.Http;

namespace BookingSite.Controllers
{
    public class HomeController : Controller
    {
        private readonly IHttpClientFactory _clientFactory;
        private readonly ILogger<HomeController> _logger;
        private readonly string baseUrl = "https://localhost:44350/api/";

        public HomeController(ILogger<HomeController> logger, IHttpClientFactory cFactory)
        {
            _logger = logger;
            _clientFactory = cFactory;
        }
        
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            //HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Get, baseUrl+"movie");
            //HttpClient client = _clientFactory.CreateClient();
            //HttpResponseMessage res = await client.SendAsync(req);

            //List<Movie> movies;
            //if (res.IsSuccessStatusCode)
            //{
            //    movies = JsonConvert.DeserializeObject<List<Movie>>(await res.Content.ReadAsStringAsync());
            //} else
            //{
            //    movies = new List<Movie>();
            //}

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> ReserveSeat(int id)
        {
            HttpRequestMessage req = new HttpRequestMessage(HttpMethod.Put, baseUrl + "movie/BookMovie/" + id);
            HttpClient client = _clientFactory.CreateClient();
            HttpResponseMessage res = await client.SendAsync(req);
            return RedirectToAction("Index");
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
