using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOperatorSystem.Core.Models.Home;
using TourOperatorSystem.Core.Models.Hotel;
using TourOperatorSystem.Core.Models.VacationCategory;

namespace TourOperatorSystem.Core.Contracts
{
	public interface IHotelService
	{
		Task<IEnumerable<HotelIndexServiceModel>> TopTreeHotelsAsync();
		Task<HotelDetailsServiceModel> HotelDetailsByIdAsync(int id);
		Task<bool> HotelExistByIdAsync(int id);
		Task<AllHotelsServiceModel> AllAsync(int hotelsPerPage, int currentPage);
		Task<IEnumerable<VacationCategoryServiceModel>> AllVacationsCategoriesAsync();
		Task<bool> VacationCategoryExistAsync(int id);
		Task<int> CreateHotelAsync(HotelFormModel model, string fileName);
		Task<HotelServiceModel> GetHotelToDeleteByIdAsync(int id);
		Task<HotelFormModel?> GetHotelToDEditByIdAsync(int id);
		Task EditAsync(int id, HotelFormModel model);
		Task DeleteHotelByIdAsync(int id);
		Task<string> GetImageAsync(int id);
		Task<IEnumerable<HotelTypesServiceModel>> AllHotelsTypesAsync();
		Task<IEnumerable<HotelTypesServiceModel>> GetAllHotelsAsync();
	}
}
