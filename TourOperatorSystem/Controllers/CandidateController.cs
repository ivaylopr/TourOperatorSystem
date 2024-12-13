using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TourOperatorSystem.Attributes;
using TourOperatorSystem.Core.Contracts;
using TourOperatorSystem.Core.Models.Candidate;

namespace TourOperatorSystem.Controllers
{
    [Authorize]
    public class CandidateController : Controller
    {
        private readonly ICandidateService candidateService;
        private readonly ISeasonalEmploymentService seasonalEmploymentService;
        public CandidateController(ICandidateService _candidateService, ISeasonalEmploymentService _seasonalEmploymentService)
        {
            candidateService = _candidateService;
            seasonalEmploymentService = _seasonalEmploymentService;
        }
        [HttpGet]
        [NotAgent]
        public async Task<IActionResult> Apply(CandidateFormModel model, int id)
        {
            model.OfferId = id;
            model.UserId = User.Id();
            return View(model);
        }
        [HttpPost]
        [NotAgent]
        public async Task<IActionResult> Apply(CandidateFormModel model)
        {
            string userId = User.Id();
            model.UserId = userId;
            if (userId == null)
            {
                return BadRequest();
            }
            if (await candidateService.UserAlreadyApllyiedAsync(userId) == true)
            {
                return RedirectToAction("All", "Seasonal");
            }
            if (ModelState.IsValid == false)
            {
                return View(model);
            }

            int candidateId = await candidateService.BecomeApplier(model, model.OfferId);
            await seasonalEmploymentService.AddNewCandidate(model.OfferId, candidateId);

            return RedirectToAction("All", "Seasonal");
        }
    }
}
