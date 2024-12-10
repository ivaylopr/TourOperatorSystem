using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TourOperatorSystem.Core.Models.Hotel;

namespace TourOperatorSystem.Controllers
{
	[Authorize]
	public class HotelController : Controller
	{
		[AllowAnonymous]
		[HttpGet]
		public IActionResult AllHotels()
		{
			var model = new AllHotelsQueryModel();
			return View();
		}
	}
}
