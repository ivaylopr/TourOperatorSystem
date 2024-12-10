using Microsoft.AspNetCore.Mvc;

namespace TourOperatorSystem.Controllers
{
	public class VacationController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
