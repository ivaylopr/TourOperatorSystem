using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TourOperatorSystem.Core.Contracts;
using TourOperatorSystem.Models;

namespace TourOperatorSystem.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> logger;
        private readonly IHotelService hotelService;
        public HomeController(ILogger<HomeController> _logger
            , IHotelService _hotelService)
        {
            logger = _logger;
            hotelService = _hotelService;
        }

        public async Task<IActionResult> Index()
        {
            var model = await hotelService.TopTreeHotelsAsync();
            return View(model);
        }

        [AllowAnonymous]
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error(int statusCode)
        {
            if (statusCode == 400)
            {
                return View("Error400");
            }

            if (statusCode == 401)
            {
                return View("Error401");
            }

            return View();
        }
    }
}
