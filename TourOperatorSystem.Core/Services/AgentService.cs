using Microsoft.EntityFrameworkCore;
using TourOperatorSystem.Core.Contracts;
using TourOperatorSystem.Core.Models.Agent;
using TourOperatorSystem.Core.Models.Comment;
using TourOperatorSystem.Infrastructure.Data.Common;
using TourOperatorSystem.Infrastructure.Data.Models;

namespace TourOperatorSystem.Core.Services
{
    public class AgentService : IAgentService
    {
        private readonly IRepository repository;
        public AgentService(IRepository _repository)
        {
            repository = _repository;
        }

        public async Task<int> AddAgent(AgentFormServiceModel model, string id)
        {
            Agent agent = new Agent()
            {
                PhoneNumber = model.PhoneNumber,
                UserId = id,
                IsActive = false,
            };
            await repository.AddAsync(agent);
            await repository.SaveChangesAsync();
            return agent.Id;
        }

        public async Task<bool> AgentAlreadyApllyiedAsync(string id)
        {
            return await repository.AllReadOnly<Agent>().AnyAsync(a => a.UserId == id);
        }

        public async Task<bool> AgentByIdExistAsync(int id)
        {
            return await repository.AllReadOnly<Agent>().AnyAsync(a => a.Id == id);
        }

        public async Task<bool> AgentIsResposiveAboutTheVacationByIdsAsync(int agentId, int entityId)
        {
            return await repository.AllReadOnly<Vacation>().AnyAsync(v => v.AgentId == agentId && v.Id == entityId);
        }

        public async Task<bool> AgentWithIdExistsAsync(string id)
        {
            return await repository.AllReadOnly<Agent>().AnyAsync(a => a.UserId == id && a.IsActive == true);
        }

        public async Task<IEnumerable<AgentServiceModel>> AllAgentsAsync()
        {
            return await repository.AllReadOnly<Agent>()
                .Select(a => new AgentServiceModel()
                {
                    Id = a.Id,
                    PhoneNumber = a.PhoneNumber,
                    UserId = a.UserId,
                    Email = a.User.Email,
                    IsActive = a.IsActive
                })
                .ToListAsync();
        }

        public async Task<IEnumerable<CommentServiceModel>> AllComentsByIdAsync(int agentId)
        {
            var agent = await repository.AllReadOnly<Agent>()
                .FirstOrDefaultAsync(a => a.Id == agentId);
            List<CommentServiceModel> comments = new List<CommentServiceModel>();
            if (agent != null)
            {
                foreach (var comment in agent.Comments)
                {
                    var commentToAdd = new CommentServiceModel()
                    {
                        Review = comment.Review,
                        UserId = comment.UserId,
                        Rating = comment.Rating
                    };
                    comments.Add(commentToAdd);
                }
            }
            return comments;

        }

        public async Task<int?> GetAgentIdAsync(string userId)
        {
            return (await repository.AllReadOnly<Agent>()
                .FirstOrDefaultAsync(a => a.UserId == userId))?.Id;
        }

        public async Task ChangeStatusById(int id)
        {
            var agentToChange = repository.All<Agent>().First(a => a.Id == id);
            if (agentToChange.IsActive == false)
            {
                agentToChange.IsActive = true;
                await repository.SaveChangesAsync();
            }
            else
            {
                agentToChange.IsActive = false;
                await repository.SaveChangesAsync();
            }
        }

    }
}
