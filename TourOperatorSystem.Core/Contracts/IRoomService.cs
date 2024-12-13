using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOperatorSystem.Core.Models.Room;

namespace TourOperatorSystem.Core.Contracts
{
	public interface IRoomService
	{
		Task<int> AddAsync(RoomFormModel model);
		Task<RoomFormModel> GetRoomByIdAsync(int Id);
		Task<AllRoomsServiceModel> All(int currentPage, int roomsPerPage);
		Task<string> GetHotelNameByRoomIdAsync(int id);
	}
}
