﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NewsFeed2MVC.Models;
using Microsoft.AspNetCore.Authorization;
using System.Net.Http;
using Newtonsoft.Json;

namespace NewsFeed2MVC.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {

            // using (HttpClient client = new HttpClient())
            //{
            //    HttpResponseMessage response = client.GetAsync("https://localhost:44325/api/values").Result;
            //    response.EnsureSuccessStatusCode();
            //    var responseBody = response.Content.ReadAsStringAsync().Result;
            //    var model = JsonConvert.DeserializeObject<List<News>>(responseBody);
            //    return View(model);
            //}

            return View();
          
        }

        [Route("from/{startYear}/{startMonth}/to/{endYear}/{endMonth}")]
         public IActionResult Index(int startYear, int startMonth, int endYear, int endMonth)
        {

             using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = client.GetAsync($"http://localhost:44325/api/values/from/{startYear}/{startMonth}/to/{endYear}/{endMonth}").Result;
                response.EnsureSuccessStatusCode();
                var responseBody = response.Content.ReadAsStringAsync().Result;
                var model = JsonConvert.DeserializeObject<List<News>>(responseBody);
                return View(model);
            }
          
        }

        public IActionResult Privacy()
        {
            return View();
        }
        [Authorize]
        public IActionResult Create()
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
