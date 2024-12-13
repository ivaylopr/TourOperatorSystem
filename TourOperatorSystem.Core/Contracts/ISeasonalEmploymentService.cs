using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOperatorSystem.Core.Models.SeasonalEmployment;

namespace TourOperatorSystem.Core.Contracts
{
	public interface ISeasonalEmploymentService
	{
		Task<AllOffersModel> AllAsync(int currentPage, int offersPerPage);
		Task<SeasonOfferDetailsViewModel> GetOfferDetailsByIdAsync(int id);
		Task<bool> SeasonOfferExistByIdAsync(int id);
		Task GetSeasonalOfferByIdAsync(int offerId, int applierId);
		Task AddNewCandidate(int offerId, int candidateId);
		//Task<int> AddSeasonOffer(SeasonalOfferFormModel model,DateTime startDate,DateTime endDate);
	}
}
