namespace TourOperatorSystem.Core.Models.Room
{
    public class AllRoomsServiceModel
	{
		public int RoomsPerPage { get; } = 3;

		public int CurrentPage { get; set; } = 1;

		public int TotalRoomslCount { get; set; }
		public IEnumerable<RoomServiceModel> Rooms { get; set; } = new List<RoomServiceModel>();
	}
}
