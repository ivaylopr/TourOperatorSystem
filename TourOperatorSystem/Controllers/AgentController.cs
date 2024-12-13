using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TourOperatorSystem.Attributes;
using TourOperatorSystem.Core.Contracts;
using TourOperatorSystem.Core.Models.Agent;

namespace TourOperatorSystem.Controllers
{
    [Authorize]
    public class AgentController : Controller
    {
        private readonly IAgentService agentService;
        public AgentController(IAgentService _agentService)
        {
            agentService = _agentService;
        }
        [HttpGet]
        [NotAgent]
        public async Task<IActionResult> Apply()
        {
            var model = new AgentFormServiceModel();
            return View(model);
        }
        [HttpPost]
        [NotAgent]
        public async Task<IActionResult> Apply(AgentFormServiceModel model)
        {
            string userId = User.Id();
            if (await agentService.AgentAlreadyApllyiedAsync(userId))
            {
                return RedirectToAction("Index", "Home");
            }
            if (userId == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            int agentId = await agentService.AddAgent(model, userId);
            return RedirectToAction(nameof(All));
        }
        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> All(IEnumerable<AgentServiceModel> model)
        {
            model = await agentService.AllAgentsAsync();


            if (model == null)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            int ratingPlus = 0;
            foreach (var agent in model)
            {
                agent.Comments = await agentService.AllComentsByIdAsync(agent.Id);
                foreach (var item in agent.Comments)
                {
                    ratingPlus += (int)item.Rating;
                }
                if (agent.Comments.Count() != 0)
                {
                    agent.Rating = ratingPlus / agent.Comments.Count();
                }
            }
            return View(model);
        }
    }
