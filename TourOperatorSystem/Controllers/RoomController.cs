using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TourOperatorSystem.Attributes;
using TourOperatorSystem.Core.Contracts;
using TourOperatorSystem.Core.Models.Room;

namespace TourOperatorSystem.Controllers
{
    [Authorize]
    public class RoomController : Controller
    {
        private readonly IRoomService roomService;
        private readonly IHotelService hotelService;
        private readonly IAgentService agentService;
        public RoomController(
            IRoomService _roomService,
            IHotelService _hotelService,
            IAgentService _agentService)
        {
            roomService = _roomService;
            hotelService = _hotelService;
            agentService = _agentService;
        }
        [HttpGet]
        [IsAgent]
        public async Task<IActionResult> Add()
        {
            var model = new RoomFormModel();

            return View(model);
        }
        [HttpPost]
        [IsAgent]
        public async Task<IActionResult> Add(RoomFormModel model)
        {
            if (await agentService.AgentWithIdExistsAsync(User.Id()) == false ||
            User.IsAdmin() == false)
            {
                return Unauthorized();
            }
            if (await hotelService.HotelExistByIdAsync(model.HotelId) == false)
            {
                return BadRequest();
            }
            if (!ModelState.IsValid)
            {
                return View(model);
            }
            await roomService.AddAsync(model);
            return RedirectToAction("All", "Hotel");
        }
        [HttpGet]
        public async Task<IActionResult> All(AllRoomsServiceModel model)
        {
            var rooms = await roomService.All(
                model.CurrentPage,
                model.RoomsPerPage);

            model.TotalRoomslCount = rooms.TotalRoomslCount;
            model.Rooms = rooms.Rooms;

            return View(model);
        }
    }
}
