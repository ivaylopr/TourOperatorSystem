using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TourOperatorSystem.Core.Contracts;
using TourOperatorSystem.Core.Models.Hotel;

namespace TourOperatorSystem.Areas.Admin.Controllers
{
	public class HotelController : AdminBaseController
	{
		private readonly ILogger<HotelController> logger;
		private readonly IHotelService hotelService;
		private readonly IWebHostEnvironment _webHostEnvironment;
		public HotelController(ILogger<HotelController> _logger,
			IHotelService _hotelService,
			IVacationService _vacationService,
			IAgentService _agentService,
			IWebHostEnvironment webHostEnvironment)
		{
			logger = _logger;
			hotelService = _hotelService;
			_webHostEnvironment = webHostEnvironment;
		}
		[HttpGet]
		public async Task<IActionResult> Add()
		{
			var model = new HotelFormModel()
			{
				VacationCategories = await hotelService.AllVacationsCategoriesAsync()
			};
			return View(model);
		}
		[HttpPost]
		public async Task<IActionResult> Add(HotelFormModel model, IFormFile imageFile)
		{
			if (User.IsAdmin() == false)
			{
				return Unauthorized();
			}
			var categoryExist = await hotelService.VacationCategoryExistAsync(model.VacationCategoryId);
			string fileName = string.Empty;
			if (imageFile != null && imageFile.Length > 0)
			{

				var uniqueFileName = model.Name.Replace(' ', '_') + "_" + imageFile.FileName;
				var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileName);
				using (var fileStream = new FileStream(filePath, FileMode.Create))
				{
					imageFile.CopyTo(fileStream);
				}
				fileName = uniqueFileName;
			}

			if (categoryExist == false)
			{
				ModelState.AddModelError(nameof(model.VacationCategoryId), "Vacation category does not exists!.");
			}
			model.VacationCategories = await hotelService.AllVacationsCategoriesAsync();
			if (!ModelState.IsValid)
			{
				model.VacationCategories = await hotelService.AllVacationsCategoriesAsync();
				return View(model);
			}
			string filePathValue = $"/images/{fileName}";
			int newHotelId = await hotelService.CreateHotelAsync(model, filePathValue);
			return RedirectToAction("Details", "Hotel", new { area = "", id = newHotelId });
		}
	}
}
