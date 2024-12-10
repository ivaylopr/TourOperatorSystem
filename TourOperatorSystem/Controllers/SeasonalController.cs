using Microsoft.AspNetCore.Mvc;

namespace TourOperatorSystem.Controllers
{
	public class SeasonalController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
