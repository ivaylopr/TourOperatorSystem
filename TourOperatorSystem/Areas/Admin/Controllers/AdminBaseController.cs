using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using static TourOperatorSystem.Core.Constants.AdministratorConstants;

namespace TourOperatorSystem.Areas.Admin.Controllers
{
	[Area("Admin")]
	[Authorize(Roles = AdminRole)]
	public class AdminBaseController : Controller
	{

	}
}
