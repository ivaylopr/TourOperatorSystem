using Microsoft.AspNetCore.Mvc;

namespace TourOperatorSystem.Controllers
{
	public class HotelController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
