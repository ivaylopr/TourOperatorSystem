using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TourOperatorSystem.Infrastructure.Data.Models
{
    public class VacationCustomer
    {
        [Required]
        public int VacationId { get; set; }
        [ForeignKey(nameof(VacationId))]
        public Vacation Vacation { get; set; } = null!;
        [Required]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
    }
}
