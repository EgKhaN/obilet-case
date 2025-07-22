using System.Diagnostics;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Newtonsoft.Json;
using oBilet.Application.Abstractions;
using oBilet.Infrastructure.OBiletAPI;
using oBilet.Presentation.Models;
using static System.Net.Mime.MediaTypeNames;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace oBilet.Presentation.Controllers
{
    public class JourneyController : Controller
    {
        private readonly ILogger<JourneyController> _logger;

        private readonly IOBiletService _obiletService;

        public JourneyController(ILogger<JourneyController> logger, IOBiletService oBiletService)
        {
            _logger = logger;
            _obiletService = oBiletService;
        }

        public async Task<IActionResult> Index(int origin, int destination, DateTime departureDate)
        {
            if(origin == destination)
            {
                return RedirectToAction("Index","Home");
            }

            var journeys = await _obiletService.GetJourneysAsync(origin, destination, departureDate);
            if (journeys == null)
            {
                _logger.LogError("Failed to retrieve journey data.");
                return View("Error");
            }

            return View(journeys);
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
