using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourOperatorSystem.Infrastructure.Data.Models
{
    public class HotelVacation
    {
        [Required]
        public int HodelId { get; set; }
        [ForeignKey(nameof(HodelId))]
        public Hotel Hotel { get; set; } = null!;
        [Required]
        public int VacationId { get; set; }
        [ForeignKey(nameof(VacationId))]
        public Vacation Vacation { get; set; } = null!;
    }
}
