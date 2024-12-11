using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TourOperatorSystem.Core.Contracts.Hotel;
using TourOperatorSystem.Core.Services;
using TourOperatorSystem.Models;

namespace TourOperatorSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IHotelService hotelService;

        public HomeController(ILogger<HomeController> logger
            ,IHotelService _hotelService)
        {
            _logger = logger;
            hotelService = _hotelService;
        }

        public async Task<IActionResult> Index()
        {
			var model = await hotelService.TopTreeHotelsAsync();
			return View(model);
		}

        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
