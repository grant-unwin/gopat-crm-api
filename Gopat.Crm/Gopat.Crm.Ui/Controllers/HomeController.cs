using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Gopat.Crm.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Gopat.Crm.Ui.Models;
using Microsoft.EntityFrameworkCore;

namespace Gopat.Crm.Ui.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly GopatContext _context;

        public HomeController(ILogger<HomeController> logger, GopatContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {

            HomeViewModel view = new HomeViewModel();
            view.Companies = await _context.Companies.OrderByDescending(c => c.Modified).Take(10).ToListAsync();

            return View(view);
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
