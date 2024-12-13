﻿using System.ComponentModel.DataAnnotations;

namespace TourOperatorSystem.Core.Models.Agent
{
	public class AgentFormServiceModel
	{
		[Required]
		[Phone]
		public string PhoneNumber { get; set; } = string.Empty;
		[Required]
		[EmailAddress]
		public string Email { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		[Display(Name = "Motivation letter")]
		[StringLength(MotivationLetterMaxLength,
		   MinimumLength = MotivationLetterMinLength,
			ErrorMessage = LengthErrorMessage)]
		public string MotivationLetter { get; set; } = string.Empty;
	}
}