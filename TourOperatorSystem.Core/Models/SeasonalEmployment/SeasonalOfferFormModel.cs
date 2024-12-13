using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using TourOperatorSystem.Core.Models.Candidate;
using static TourOperatorSystem.Core.Constants.MessageConstants;
using static TourOperatorSystem.Infrastructure.Constants.DataConstants;

namespace TourOperatorSystem.Core.Models.SeasonalEmployment
{
    public class SeasonalOfferFormModel
	{
		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(SeasonEmploymentTitleMaxLength,
			MinimumLength = SeasonEmploymentTitleMinLength,
			ErrorMessage = LengthErrorMessage)]
		[Comment("Job title")]
		public string Title { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(SeasonEmploymentDescriptionMaxLength,
			MinimumLength = SeasonEmploymentDescriptionMinLength,
			ErrorMessage = LengthErrorMessage)]
		[Comment("Job description")]
		public string Description { get; set; } = string.Empty;
		[Required]
		[Comment("Payment per hour")]
		public decimal HourlyWage { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		[Comment("Data for starting job")]
		public string StartDate { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		[Comment("End date for the job")]
		public string EndDate { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		[Comment("Agent responsible for the offer")]
		public int AgentId { get; set; }
		[Required]
		[Comment("Hotel who is offering the season job")]
		public int HotelId { get; set; }
		[Required]
		public bool IsActive { get; set; }
		public IEnumerable<CandidateServiceModel> Applyers { get; set; } = new List<CandidateServiceModel>();
	}
}
