using Microsoft.EntityFrameworkCore;
using TourOperatorSystem.Core.Contracts.Hotel;
using TourOperatorSystem.Core.Models.Hotel;
using TourOperatorSystem.Infrastructure.Data.Common;
using TourOperatorSystem.Infrastructure.Data.Models;

namespace TourOperatorSystem.Core.Services
{
	public class HotelService : IHotelService
	{
		private readonly IRepository repository;

		public HotelService(IRepository _repository)
		{
			repository = _repository;
		}

        public async Task<AllHotelsServiceModel> AllAsync(
            int currentPage = 1
            , int hotelsPerPage = 1)
        {
            {
                var hotelsResult = repository.AllReadOnly<Hotel>();


                var hotels = await hotelsResult
                    .Skip((currentPage - 1) * hotelsPerPage)
                    .Take(hotelsPerPage)
                    .Select(h => new HotelServiceModel()
                    {
                        Id = h.Id,
                        Name = h.Name,
                        Location = h.Location,
                        Image = h.Image != null
                                ? Convert.ToBase64String(h.Image)
                                : null,
                    })
                    .ToListAsync();

                int totalHotels = await hotelsResult.CountAsync();

                return new AllHotelsServiceModel()
                {
                    Hotels = hotels,
                    TotalHotelCount = totalHotels
                };
            }
        }

        public async Task<IEnumerable<HotelIndexServiceModel>> TopTreeHotelsAsync()
		{
			return await repository.AllReadOnly<Hotel>()
					.OrderByDescending(h => h.Rating)
					.Take(3)
					.Select(h => new HotelIndexServiceModel()
					{
						Id = h.Id,
						Name = h.Name,
						Image = h.Image != null
								? Convert.ToBase64String(h.Image)
								: null,
						Rating = h.Rating ?? 0
					}).ToListAsync();
		}
	}
}
