using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using TourOperatorSystem.Attributes;
using TourOperatorSystem.Core.Contracts;
using TourOperatorSystem.Core.Models.Hotel;

namespace TourOperatorSystem.Controllers
{
    [Authorize]
    public class HotelController : Controller
    {
        private readonly ILogger<HotelController> logger;
        private readonly IHotelService hotelService;
        private readonly IVacationService vacationService;
        private readonly IAgentService agentService;
        private readonly IWebHostEnvironment _webHostEnvironment;
        public HotelController(ILogger<HotelController> _logger,
            IHotelService _hotelService,
            IVacationService _vacationService,
            IAgentService _agentService,
            IWebHostEnvironment webHostEnvironment)
        {
            logger = _logger;
            hotelService = _hotelService;
            vacationService = _vacationService;
            agentService = _agentService;
            _webHostEnvironment = webHostEnvironment;
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> All(AllHotelsServiceModel model)
        {
            var hotels = await hotelService.AllAsync(
                model.CurrentPage,
                model.HotelsPerPage);

            model.TotalHotelCount = hotels.TotalHotelCount;
            model.Hotels = hotels.Hotels;

            return View(model);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            if (User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            if (await hotelService.HotelExistByIdAsync(id) == false)
            {
                return BadRequest();
            }
            var model = await hotelService.GetHotelToDeleteByIdAsync(id);

            return View(model);
        }
        [HttpPost]
        [IsAgent]
        public async Task<IActionResult> Delete(HotelServiceModel model)
        {
            if (await agentService.AgentWithIdExistsAsync(User.Id()) == false ||
                User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            if (await hotelService.HotelExistByIdAsync(model.Id) == false)
            {
                return BadRequest();
            }
            var filledModel = await hotelService.GetHotelToDeleteByIdAsync(model.Id);
            string webRootPath = _webHostEnvironment.WebRootPath;
            string filePathToDelete = filledModel.Image;
            string fullPathToDelete = Path.Combine(webRootPath, filePathToDelete.TrimStart('/'));

            if (System.IO.File.Exists(fullPathToDelete))
            {
                System.IO.File.Delete(fullPathToDelete);
            }

            await hotelService.DeleteHotelByIdAsync(model.Id);
            return RedirectToAction(nameof(Index), "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Details(int id)
        {
            if (await hotelService.HotelExistByIdAsync(id) == false)
            {
                return BadRequest();
            }
            var model = await hotelService.HotelDetailsByIdAsync(id);
            return View(model);
        }
        [HttpGet]
        [IsAgent]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await hotelService.GetHotelToDEditByIdAsync(id);
            if (model == null)
            {
                return BadRequest();
            }
            model.VacationCategories = await hotelService.AllVacationsCategoriesAsync();
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(int id, HotelFormModel model, IFormFile imageFile)
        {
            if (await agentService.AgentWithIdExistsAsync(User.Id()) == false ||
                User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            if (await hotelService.HotelExistByIdAsync(id) == false)
            {
                return BadRequest();
            }

            if (imageFile == null)
            {
                model.Image = await hotelService.GetImageAsync(id);
                ModelState["imageFile"].ValidationState = ModelValidationState.Valid;
            }

            if (imageFile != null && imageFile.Length > 0)
            {
                var filledModel = await hotelService.GetHotelToDeleteByIdAsync(id);
                string webRootPath = _webHostEnvironment.WebRootPath;
                string filePathToDelete = filledModel.Image;
                string fullPathToDelete = Path.Combine(webRootPath, filePathToDelete.TrimStart('/'));

                if (System.IO.File.Exists(fullPathToDelete))
                {
                    System.IO.File.Delete(fullPathToDelete);
                }

                string fileName = string.Empty;
                var uniqueFileName = model.Name.Replace(' ', '_') + "new" + imageFile.FileName;
                var filePath = Path.Combine(_webHostEnvironment.WebRootPath, "images", uniqueFileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    imageFile.CopyTo(fileStream);
                }
                fileName = uniqueFileName;
                string filePathValue = $"/images/{fileName}";
                model.Image = filePathValue;
            }

            var categoryExist = await hotelService.VacationCategoryExistAsync(model.VacationCategoryId);

            if (categoryExist == false)
            {
                ModelState.AddModelError(nameof(model.VacationCategoryId), "Vacation of this type does not exist");
            }

            if (!ModelState.IsValid)
            {
                model.VacationCategories = await hotelService.AllVacationsCategoriesAsync();
                return View(model);
            }

            await hotelService.EditAsync(id, model);

            return RedirectToAction(nameof(Details), new { id = id });
        }
    }
}
