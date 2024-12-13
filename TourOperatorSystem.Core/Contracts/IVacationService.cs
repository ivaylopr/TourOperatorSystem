using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOperatorSystem.Core.Models.Vacation;

namespace TourOperatorSystem.Core.Contracts
{
	public interface IVacationService
	{
		Task<IEnumerable<string>> AllCategoriesNamesAsync();
		string CategoryNameByIdAsync(int id);
		Task<AllVacatinsServiceModel> AllAsync(
			int currentPage = 1
			, int hotelsPerPage = 1);
		Task<bool> VacationExistByIdAsync(int id);
		Task<VacationFormModel> GetVacationByIdAsync(int id);
		Task<int> CreateVacationAsync(
			VacationFormModel vacationDateTime,
			DateTime enrollmentDate,
			DateTime startDate,
			DateTime endDate);
		Task<VacationServiceModel?> GetVacationDetailsByIdAsync(int id);
		Task<AllVacatinsServiceModel> JoinedByUserIdAsync(string id, int currentPage, int totalModelCount);
		Task JoinVacationAsync(int id, string userId);
		Task<bool> IsInVacationUserById(string id, int vacationId);
	}
}
