using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using TotallyNotXSSVulnerable.Models;

namespace TotallyNotXSSVulnerable.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly XSSContext _context;

        public HomeController(ILogger<HomeController> logger, XSSContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            IndexVM vm = new IndexVM
            {
                Comments = await _context.Comment.ToListAsync(),
                CommentContent = String.Empty
            };

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> Index([Bind("CommentContent")] IndexVM vm)
        {
            _context.Add(new Comment { Content = vm.CommentContent });
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
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
