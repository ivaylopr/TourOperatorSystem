using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOperatorSystem.Core.Models.Candidate;

namespace TourOperatorSystem.Core.Contracts
{
	public interface ICandidateService
	{
		Task<bool> CandidateExistByIdAsync(int id);
		Task<IEnumerable<CandidateServiceModel>> GetAllCandidateAsync();
		Task<int> BecomeApplier(CandidateFormModel model, int offerId);
		Task<bool> UserAlreadyApllyiedAsync(string id);
	}
}
