using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TourOperatorSystem.Core.Contracts;
using TourOperatorSystem.Core.Models.SeasonalEmployment;

namespace TourOperatorSystem.Controllers
{
	
        [Authorize]
        public class SeasonalController : Controller
        {
            private readonly ISeasonalEmploymentService seasonalEmploymentService;
            private readonly ICandidateService candidateService;
            public SeasonalController(
                ISeasonalEmploymentService _seasonalEmploymentService,
                ICandidateService _candidateService)
            {
                seasonalEmploymentService = _seasonalEmploymentService;
                candidateService = _candidateService;
            }

            [HttpGet]
            public async Task<IActionResult> All(AllOffersModel model)
            {
                var offers = await seasonalEmploymentService.AllAsync(
                    model.CurrentPage,
                    model.OfferPerPage);

                model.TotalOffersCount = offers.TotalOffersCount;
                model.SeasonalEmployments = offers.SeasonalEmployments;

                return View(model);
            }
            [HttpGet]
            public async Task<IActionResult> Details(int id)
            {
                if (await seasonalEmploymentService.SeasonOfferExistByIdAsync(id) == false)
                {
                    return BadRequest();
                }
                var model = await seasonalEmploymentService.GetOfferDetailsByIdAsync(id);

                return View(model);
            }
        }
    }

