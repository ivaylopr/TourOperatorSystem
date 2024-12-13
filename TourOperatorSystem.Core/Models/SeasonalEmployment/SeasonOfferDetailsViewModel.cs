using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOperatorSystem.Core.Models.SeasonalEmployment
{
	public class SeasonOfferDetailsViewModel
	{
		public string Title { get; set; } = string.Empty;
		public string Description { get; set; } = string.Empty;
		public decimal HourlyWage { get; set; }
		public string StartDate { get; set; } = string.Empty;
		public string EndDate { get; set; } = string.Empty;
		[Display(Name = "Agent responsive for the offer phone number")]
		public string AgentPhoneNumber { get; set; } = null!;
		public string Hotel { get; set; } = null!;
		[Display(Name = "Hotel name")]
		public string HotelName { get; set; } = null!;
		public bool IsActive { get; set; }
	}
}
