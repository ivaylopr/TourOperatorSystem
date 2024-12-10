using Microsoft.AspNetCore.Mvc;

namespace TourOperatorSystem.Controllers
{
	public class CandidateController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
