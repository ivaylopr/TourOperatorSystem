using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TourOperatorSystem.Infrastructure.Constants.DataConstants;

namespace TourOperatorSystem.Infrastructure.Data.Models
{
    [Comment("Season job class")]
    public class SeasonalEmployment
    {
        [Key]
        [Comment("Identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(SeasonEmploymentTitleMaxLength)]
        [Comment("Job title")]
        public string Title { get; set; } = string.Empty;
        [Required]
        [MaxLength(SeasonEmploymentDescriptionMaxLength)]
        [Comment("Job description")]
        public string Description { get; set; } = string.Empty;
        [Required]
        [Comment("Payment per hour")]
        public decimal HourlyWage { get; set; }
        [Required]
        [Comment("Data for starting job")]
        public DateTime StartDate { get; set; }
        [Required]
        [Comment("End date for the job")]
        public DateTime EndDate { get; set; }
        [Required]
        [Comment("Agent responsible for the offer")]
        public int AgentId { get; set; }
        [ForeignKey(nameof(AgentId))]
        public Agent Agent { get; set; } = null!;
        [Required]
        [Comment("Hotel who is offering the season job")]
        public int HotelId { get; set; }
        [ForeignKey(nameof(HotelId))]
        public Hotel Hotel { get; set; } = null!;
        [Required]
        public bool IsActive { get; set; }
        [Comment("Users who is applied the offer")]
        public IList<Candidate> Applayers { get; set; } = new List<Candidate>();
    }
}
