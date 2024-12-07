using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TourOperatorSystem.Infrastructure.Constants.DataConstants;

namespace TourOperatorSystem.Infrastructure.Data.Models
{
    public class HotelRoom
    {
        [Required]
        public int HotelId { get; set; }
        [ForeignKey(nameof(HotelId))]
        public Hotel Hotel { get; set; } = null!;
        [Required]
        public int RoomId { get; set; }
        [ForeignKey(nameof(RoomId))]
        public Room Room { get; set; } = null!;
    }
}
