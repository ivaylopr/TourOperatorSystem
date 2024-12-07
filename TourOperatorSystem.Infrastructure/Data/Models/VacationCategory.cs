using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using static TourOperatorSystem.Infrastructure.Constants.DataConstants;

namespace TourOperatorSystem.Infrastructure.Data.Models
{
    [Comment("Category class for vacations")]
    public class VacationCategory
    {
        [Key]
        [Comment("Category identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(VacationCategoryTypeMaxLength)]
        [Comment("Type of the vacation")]
        public string VacationType { get; set; } = string.Empty;
        [MaxLength(VacationCategoryDescriptionMaxLength)]
        [Comment("Description of the type")]
        public string? Description { get; set; }
        public IEnumerable<Vacation> Vacations { get; set; } = new List<Vacation>();
        public IEnumerable<Hotel> Hotels { get; set; } = new List<Hotel>();
    }
}
