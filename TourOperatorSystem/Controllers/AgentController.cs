using Microsoft.AspNetCore.Mvc;

namespace TourOperatorSystem.Controllers
{
	public class AgentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
