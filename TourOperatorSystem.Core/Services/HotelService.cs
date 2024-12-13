using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Internal;
using Microsoft.EntityFrameworkCore;
using TourOperatorSystem.Core.Contracts;
using TourOperatorSystem.Core.Models.Home;
using TourOperatorSystem.Core.Models.Hotel;
using TourOperatorSystem.Core.Models.VacationCategory;
using TourOperatorSystem.Infrastructure.Data.Common;
using TourOperatorSystem.Infrastructure.Data.Models;

namespace TourOperatorSystem.Core.Services
{
    public class HotelService : IHotelService
    {
        private readonly IRepository repository;
        private readonly IVacationService vacationService;
        public HotelService(IRepository _repository,
            IVacationService _vacationService)
        {
            repository = _repository;
            vacationService = _vacationService;
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
                        Image = Convert.ToBase64String(h.Image ?? Array.Empty<byte>())
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

        public async Task<IEnumerable<HotelTypesServiceModel>> AllHotelsTypesAsync()
        {
            return await repository.AllReadOnly<Hotel>()
                .Select(h => new HotelTypesServiceModel()
                {
                    Id = h.Id,
                    Name = h.Name,
                    Image = Convert.ToBase64String(h.Image ?? Array.Empty<byte>())
                }).ToListAsync();
        }

        public async Task<IEnumerable<VacationCategoryServiceModel>> AllVacationsCategoriesAsync()
        {
            return await repository.AllReadOnly<VacationCategory>()
                .Select(h => new VacationCategoryServiceModel()
                {
                    Id = h.Id,
                    VacationType = h.VacationType,
                }).ToListAsync();
        }

        public async Task<int> CreateHotelAsync(HotelFormModel model)
        {
            byte[] imageData;
            using (var memoryStream = new MemoryStream())
            {
                await model.Image.CopyToAsync(memoryStream);
                imageData = memoryStream.ToArray();
            }
            Hotel hotel = new Hotel()
            {
                Name = model.Name,
                HotelReview = model.HotelReview,
                Spa = model.Spa,
                Pool = model.Pool,
                AllInclusivePrice = model.AllInclusivePrice ?? null,
                ChildrenAnimators = model.ChildrenAnimators,
                Location = model.Location,
                Capacity = model.Capacity,
                CategoryStars = model.CategoryStars,
                Rating = model.Rating ?? null,
                Image = imageData,
                VacationCategoryId = model.VacationCategoryId

            };

            await repository.AddAsync(hotel);
            await repository.SaveChangesAsync();

            return hotel.Id;
        }

        public async Task DeleteHotelByIdAsync(int id)
        {
            await repository.DeleteAsync<Hotel>(id);
            await repository.SaveChangesAsync();
        }

        public async Task EditAsync(int id, HotelFormModel model)
        {
            var hotel = await repository.GetByIdAsync<Hotel>(id);
            
            if (hotel != null)
            {
                hotel.Name = model.Name;
                hotel.Location = model.Location;
                hotel.HotelReview = model.HotelReview;
                hotel.Spa = model.Spa;
                hotel.Pool = model.Pool;
                hotel.ChildrenAnimators = model.ChildrenAnimators;
                hotel.AllInclusivePrice = model.AllInclusivePrice ?? hotel.AllInclusivePrice;
                hotel.Capacity = model.Capacity;
                hotel.CategoryStars = model.CategoryStars;
                hotel.Rating = model.Rating ?? hotel.Rating;
                hotel.VacationCategoryId = model.VacationCategoryId;
                if (model.Image != null && model.Image.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await model.Image.CopyToAsync(memoryStream);
                        hotel.Image = memoryStream.ToArray(); 
                    }
                }
                await repository.SaveChangesAsync();
            }

        }

        public async Task<IEnumerable<HotelTypesServiceModel>> GetAllHotelsAsync()
        {
            return await repository.AllReadOnly<Hotel>()
                .Select(h => new HotelTypesServiceModel()
                {
                    Id = h.Id,
                    Name = h.Name,
                    Image = Convert.ToBase64String(h.Image ?? Array.Empty<byte>())
                }).ToListAsync();
        }

        public async Task<HotelFormModel?> GetHotelToDEditByIdAsync(int id)
        {
            return await repository.AllReadOnly<Hotel>()
                .Where(h => h.Id == id)
                .Select(h => new HotelFormModel()
                {
                    Name = h.Name,
                    HotelReview = h.HotelReview,
                    Spa = h.Spa,
                    Location = h.Location,
                    Pool = h.Pool,
                    ChildrenAnimators = h.ChildrenAnimators,
                    AllInclusivePrice = h.AllInclusivePrice ?? null,
                    Capacity = h.Capacity,
                    CategoryStars = h.CategoryStars,
                    Rating = h.Rating ?? null,
                    Image = h.Image != null ? ConvertToFormFile(h.Image, "image.png", "image/png") : null,
                    VacationCategoryId = h.VacationCategoryId
                })
                .FirstOrDefaultAsync();

        }

        private IFormFile ConvertToFormFile(byte[] image, string imageName, string contentType)
        {
            var stream = new MemoryStream(image);
            return new FormFile(stream, 0, image.Length, "file", imageName)
            {
                Headers = new HeaderDictionary(),
                ContentType = contentType
            };
        }

        public async Task<HotelServiceModel> GetHotelToDeleteByIdAsync(int id)
        {
            return await repository.AllReadOnly<Hotel>()
                .Where(h => h.Id == id)
                .Select(h => new HotelServiceModel()
                {
                    Id = h.Id,
                    Name = h.Name,
                    Location = h.Location,
                    Image = Convert.ToBase64String(h.Image ?? Array.Empty<byte>()),
                    VacationType = h.VacationCategory.VacationType
                }).FirstAsync();
        }

        public async Task<string> GetImageAsync(int id)
        {
            return await repository.AllReadOnly<Hotel>()
                .Where(h => h.Id == id)
                .Select(h => Convert.ToBase64String(h.Image ?? Array.Empty<byte>()))
                .FirstAsync();
        }

        public async Task<HotelDetailsServiceModel> HotelDetailsByIdAsync(int id)
        {
            return await repository.AllReadOnly<Hotel>()
                .Where(h => h.Id == id)
                .Select(h => new HotelDetailsServiceModel()
                {
                    Id = h.Id,
                    Name = h.Name,
                    CategoryStars = h.CategoryStars,
                    HotelReview = h.HotelReview,
                    Spa = h.Spa,
                    Pool = h.Pool,
                    ChildrenAnimators = h.ChildrenAnimators,
                    AllInclusivePrice = h.AllInclusivePrice,
                    Location = h.Location,
                    Rating = h.Rating,
                    Image = h.Image != null ? $"data:image/png;base64,{Convert.ToBase64String(h.Image)}" : null
                })
                .FirstAsync();
        }

        public Task<bool> HotelExistByIdAsync(int id)
        {
            return repository.AllReadOnly<Hotel>().AnyAsync(h => h.Id == id);
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
                    Image = h.Image != null ? $"data:image/png;base64,{Convert.ToBase64String(h.Image)}" : null,
                    Rating = h.Rating ?? 0
                })
                .ToListAsync();
        }

        public async Task<bool> VacationCategoryExistAsync(int id)
        {
            return await repository.AllReadOnly<VacationCategory>().AnyAsync(vc => vc.Id == id);
        }
    }
    
}
