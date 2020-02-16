using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Mono_Project.Models;
using Project.Service.Interfaces;
using Project.Service.Model;

namespace Mono_Project.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IVehicleMakeService _vehicleMakeService;

        public HomeController(ILogger<HomeController> logger, IVehicleMakeService vehicleMakeService)
        {
            _logger = logger;
            _vehicleMakeService = vehicleMakeService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int page)
        {
            return View();
        }

        public async Task<IActionResult> VehicleMakeList()
        {
            var results = await _vehicleMakeService.GetAllAsync(0, 3);
            return View(results);
        }

        public async Task<IActionResult> Privacy()
        {
            await _vehicleMakeService.CreateAsync(new VehicleMake { Name = "Ford", Abrv = "FD" });
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
