using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Globalization;
using TourOperatorSystem.Attributes;
using TourOperatorSystem.Core.Contracts;
using TourOperatorSystem.Core.Models.Vacation;

namespace TourOperatorSystem.Controllers
{

    [Authorize]
        public class VacationController : Controller
        {
            private readonly IVacationService vacationService;
            private readonly IAgentService agentService;
            private readonly IHotelService hotelService;
            public VacationController(
                IVacationService _vacationService,
                IAgentService _agentService,
                IHotelService _hotelService)
            {
                vacationService = _vacationService;
                agentService = _agentService;
                hotelService = _hotelService;
            }
            [HttpGet]
            [AllowAnonymous]
            public async Task<IActionResult> All(AllVacatinsServiceModel model)
            {

                var vacations = await vacationService.AllAsync(model.CurrentPage, model.VacatonsPerPage);

                model.TotalVacationsCount = vacations.TotalVacationsCount;
                model.Vacations = vacations.Vacations;

                return View(model);

            }
            [HttpGet]
            [IsAgent]
            public async Task<IActionResult> Add()
            {
                var model = new VacationFormModel()
                {
                    Categories = await hotelService.AllVacationsCategoriesAsync(),
                    Hotels = await hotelService.GetAllHotelsAsync(),
                    AgentId = await agentService.GetAgentIdAsync(User.Id()) ?? 0
                };
                return View(model);
            }
            [HttpPost]
            [IsAgent]
            public async Task<IActionResult> Add(VacationFormModel model)
            {
                if (await agentService.AgentWithIdExistsAsync(User.Id()) == false ||
        User.IsAdmin() == false)
                {
                    return Unauthorized();
                }
                DateTime enrollmentDate = DateTime.Now;
                if (!DateTime.TryParseExact(model.EnrollmentDeadline, 
                    Infrastructure.Constants.DataConstants.DateFormat,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out enrollmentDate))
                {
                    ModelState.AddModelError(nameof(model.EnrollmentDeadline),
                        $"Invalid date/time format! It must be: {Infrastructure.Constants.DataConstants.DateFormat}");
                }
                DateTime start = DateTime.Now;
                if (!DateTime.TryParseExact(model.StartDate,
                    Infrastructure.Constants.DataConstants.DateFormat,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out start))
                {
                    ModelState.AddModelError(nameof(model.StartDate),
                        $"Invalid date/time format! It must be: {Infrastructure.Constants.DataConstants.DateFormat}");
                }
                DateTime end = DateTime.Now;
                if (!DateTime.TryParseExact(model.EndDate,
                    Infrastructure.Constants.DataConstants.DateFormat,
                    CultureInfo.InvariantCulture,
                    DateTimeStyles.None,
                    out end))
                {
                    ModelState.AddModelError(nameof(model.StartDate),
                        $"Invalid date/time format! It must be: {Infrastructure.Constants.DataConstants.DateFormat}");
                }

                if (await hotelService.VacationCategoryExistAsync(model.VacationCategoryId) == false)
                {
                    ModelState.AddModelError(nameof(model.VacationCategoryId), "Category does not exist!");
                }
                if (await hotelService.HotelExistByIdAsync(model.HotelId) == false)
                {
                    ModelState.AddModelError(nameof(model.VacationCategoryId), "Hotel does not exist!");
                }
                if (enrollmentDate > start)
                {
                    ModelState.AddModelError(nameof(model.EnrollmentDeadline), "EnrollmentDeadLine must be before start of the vacation!");
                }
                if (start > end)
                {
                    ModelState.AddModelError(nameof(model.StartDate), "The vacation start must be before the end!");
                }

                model.AgentId = await agentService.GetAgentIdAsync(User.Id()) ?? 0;

                if (!ModelState.IsValid)
                {
                    model.Categories = await hotelService.AllVacationsCategoriesAsync();
                    model.Hotels = await hotelService.GetAllHotelsAsync();
                    model.AgentId = await agentService.GetAgentIdAsync(User.Id()) ?? 0;
                    return View(model);
                }

                await vacationService.CreateVacationAsync(model, enrollmentDate, start, end);
                return RedirectToAction(nameof(All));
            }

            [HttpGet]
            public async Task<IActionResult> Details(int id)
            {
                var model = await vacationService.GetVacationDetailsByIdAsync(id);
                if (model == null)
                {
                    return BadRequest();
                }
                return View(model);
            }

            [HttpPost]
            [NotAgent]
            public async Task<IActionResult> Join(int id)
            {
                if (await vacationService.VacationExistByIdAsync(id) == false)
                {
                    return BadRequest();
                }
                if (await agentService.AgentWithIdExistsAsync(User.Id()))
                {
                    return RedirectToAction(nameof(All));
                }
                if (await vacationService.IsInVacationUserById(User.Id(), id))
                {
                    return RedirectToAction(nameof(Joined));
                }
                await vacationService.JoinVacationAsync(id, User.Id());
                return RedirectToAction(nameof(Joined));
            }

            [HttpGet]
            public async Task<IActionResult> Joined(AllVacatinsServiceModel model)
            {
                if (await agentService.AgentWithIdExistsAsync(User.Id()) == true && User.IsAdmin() == false)
                {
                    return Unauthorized();
                }
                if (await agentService.AgentWithIdExistsAsync(User.Id()))
                {
                    return RedirectToAction(nameof(All));
                }

                var joinedVacations = await vacationService.JoinedByUserIdAsync(User.Id(), model.CurrentPage, model.VacatonsPerPage);

                model.TotalVacationsCount = joinedVacations.TotalVacationsCount;
                model.Vacations = joinedVacations.Vacations;

                return View(model);
            }


        }
    }

