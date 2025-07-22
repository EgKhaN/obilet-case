using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using oBilet.Application.Abstractions;
using oBilet.Infrastructure.OBiletAPI;
using oBilet.Presentation.Models;
using static System.Net.Mime.MediaTypeNames;

namespace oBilet.Presentation.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private readonly IOBiletService _obiletService;

        public HomeController(ILogger<HomeController> logger, IOBiletService oBiletService)
        {
            _logger = logger;
            _obiletService = oBiletService;
        }

        public async Task<IActionResult> Index()
        {
            var allLocationsResult = await _obiletService.GetBusLocationsAsync();
            if(allLocationsResult.IsFailure)
            {
                _logger.LogError("Failed to location session information."); //:TODO
                return View("Error");
            }

            ViewBag.locations = new SelectList(allLocationsResult.Value.Select(q=> new SelectListItem { Text = q.Name , Value = q.ID.ToString()}).ToList(),"Value","Text");
            return View();
        }

        public async Task<IActionResult> SearchLocations(string text)
        {
            var allLocationsResult = await _obiletService.GetBusLocationsAsync(text);
            if (allLocationsResult.IsFailure)
            {
                _logger.LogError("Failed to location session information.");
                return View("Error");
            }

            ViewBag.locations = new SelectList(allLocationsResult.Value.Select(q => new SelectListItem { Text = q.Name, Value = q.ID.ToString() }).ToList(), "Value", "Text");
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
