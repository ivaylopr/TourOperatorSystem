using Microsoft.AspNetCore.Mvc;

namespace TourOperatorSystem.Areas.Admin.Controllers
{
	public class HomeController : AdminBaseController
	{
		public IActionResult Home()
		{
			return View();
		}
	}
}
