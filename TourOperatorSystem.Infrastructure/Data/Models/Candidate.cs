using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TourOperatorSystem.Infrastructure.Constants.DataConstants;

namespace TourOperatorSystem.Infrastructure.Data.Models
{
    [Comment("Candidate class")]
    public class Candidate
    {
        [Key]
        [Comment("Candidate identifier")]
        public int Id { get; set; }
        [Required]
        [Comment("User-Candidate")]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
        [Required]
        [Comment("Phone number of the candidate")]
        public string PhoneNumber { get; set; } = null!;
        [Comment("Candidate email")]
        public string? Email { get; set; }
        [Comment("Is the candidate availeble")]
        public bool IsAvaileble { get; set; }
        [Required]
        public int SeasonalEmploymentId { get; set; }
        [ForeignKey(nameof(SeasonalEmploymentId))]
        public SeasonalEmployment SeasonalEmployment { get; set; } = null!;
        [Required]
        [MaxLength(CandidatePresentationMaxLength)]
        [Comment("Short presentation and skills of the candidate")]
        public string ShortRepresentAndSkills { get; set; } = string.Empty;
    }
}
