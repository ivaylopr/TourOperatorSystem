using Microsoft.EntityFrameworkCore;
using TourOperatorSystem.Core.Contracts;
using TourOperatorSystem.Core.Models.Room;
using TourOperatorSystem.Infrastructure.Data.Common;
using TourOperatorSystem.Infrastructure.Data.Models;

namespace TourOperatorSystem.Core.Services
{
    public class RoomService : IRoomService
    {
        private readonly IRepository repository;
        public RoomService(IRepository _repository)
        {
            repository = _repository;
        }
        public async Task<int> AddAsync(RoomFormModel model)
        {
            var room = new Room()
            {
                Title = model.Title,
                Description = model.Description,
                Price = model.Price,
                AdditionalExtras = model.AdditionalExtras,
                Count = model.Count
            };
            await repository.AddAsync(room);
            await repository.SaveChangesAsync();
            var newHotelRoom = new HotelRoom()
            {
                RoomId = room.Id,
                HotelId = model.HotelId
            };
            await repository.AddAsync(newHotelRoom);
            await repository.SaveChangesAsync();
            return room.Id;
        }

        public Task<RoomFormModel> GetRoomByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }
        public async Task<AllRoomsServiceModel> All(int currentPage = 1, int roomPerPage = 1)
        {
            var rooms = repository.AllReadOnly<Room>();
            IEnumerable<RoomServiceModel> roomsResult = await rooms
                    .Skip((currentPage - 1) * roomPerPage)
                    .Take(roomPerPage)
                    .Select(r => new RoomServiceModel()
                    {
                        Id = r.Id,
                        Title = r.Title,
                        Description = r.Description,
                        AdditionalExtras = r.AdditionalExtras,
                        Price = r.Price,
                        Count = r.Count
                    })
                    .ToListAsync();
            int totalRoomsCount = await rooms.CountAsync();
            foreach (var room in roomsResult)
            {
                room.HotelName = await GetHotelNameByRoomIdAsync(room.Id);
            }
            return new AllRoomsServiceModel()
            {
                Rooms = roomsResult,
                TotalRoomslCount = totalRoomsCount
            };
        }

        public Task<string> GetHotelNameByRoomIdAsync(int id)
        {
            return repository.AllReadOnly<HotelRoom>().Where(hr => hr.RoomId == id).Select(hr => hr.Hotel.Name).FirstAsync();
        }
    }
}
