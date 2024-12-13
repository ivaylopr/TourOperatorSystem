using TourOperatorSystem.Core.Models.Agent;
using TourOperatorSystem.Core.Models.Comment;

namespace TourOperatorSystem.Core.Contracts
{
	public interface IAgentService
	{
		Task<bool> AgentWithIdExistsAsync(string id);
		Task<int?> GetAgentIdAsync(string userId);
		Task<bool> AgentAlreadyApllyiedAsync(string id);
		Task<int> AddAgent(AgentFormServiceModel agent, string id);
		Task<IEnumerable<AgentServiceModel>> AllAgentsAsync();
		Task<IEnumerable<CommentServiceModel>> AllComentsByIdAsync(int agentId);
		Task<bool> AgentIsResposiveAboutTheVacationByIdsAsync(int agentId, int entityId);
		Task<bool> AgentByIdExistAsync(int id);
		Task ChangeStatusById(int id);
	}
}
