using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOperatorSystem.Core.Models.Candidate
{
	public class CandidateFormModel
	{
		[Required(ErrorMessage = RequiredMessage)]
		public string UserId { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		[Phone]
		public string PhoneNumber { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		public bool IsAvailable { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(CandidatePresentationMaxLength,
			MinimumLength = CandidatePresentationMinLength,
			ErrorMessage = LengthErrorMessage)]
		public string ShortRepresentAndSkills { get; set; } = string.Empty;
		[Required]
		public int OfferId { get; set; }
	}
}
