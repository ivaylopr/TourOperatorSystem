using Microsoft.AspNetCore.Mvc;

namespace TourOperatorSystem.Controllers
{
	public class CommentController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}
	}
}
