using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using TourOperatorSystem.Core.Contracts;
using TourOperatorSystem.Core.Models.Agent;

namespace TourOperatorSystem.Areas.Admin.Controllers
{
	public class AgentController : AdminBaseController
	{
		private readonly IAgentService agentService;
		public AgentController(IAgentService _agentService)
		{
			agentService = _agentService;
		}
		[HttpGet]
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
		[HttpPost]
		public async Task<IActionResult> ChangeStatus(int id)
		{
			if (User.IsAdmin() == false)
			{
				return Unauthorized();
			}
			if (await agentService.AgentByIdExistAsync(id) == false)
			{
				return BadRequest();
			}
			var model = agentService.ChangeStatusById(id);

			return RedirectToAction(nameof(All));
		}

	}
}
