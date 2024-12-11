using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TourOperatorSystem.Core.Contracts.Hotel;
using TourOperatorSystem.Core.Models.Hotel;

namespace TourOperatorSystem.Controllers
{
    [Authorize]
	public class HotelController : Controller
	{
        private readonly IHotelService hotelService;
        public HotelController(IHotelService _hotelService)
        {
            hotelService = _hotelService;
        }
		

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All(AllHotelsServiceModel model)
        {
            var hotels = await hotelService.AllAsync(
                model.CurrentPage,
                model.HotelsPerPage);

            model.TotalHotelCount = hotels.TotalHotelCount;
            model.Hotels = hotels.Hotels;

            return View(model);
        }
    }
}
