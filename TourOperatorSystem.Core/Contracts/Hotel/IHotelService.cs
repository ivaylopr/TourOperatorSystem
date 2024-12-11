using TourOperatorSystem.Core.Models.Hotel;

namespace TourOperatorSystem.Core.Contracts.Hotel
{
	public interface IHotelService
	{
		Task<IEnumerable<HotelIndexServiceModel>> TopTreeHotelsAsync();
        Task<AllHotelsServiceModel> AllAsync(int hotelsPerPage, int currentPage);
    }
}
