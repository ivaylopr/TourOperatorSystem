using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOperatorSystem.Core.Models.Candidate
{
	public class CandidateServiceModel
	{
		public int Id { get; set; }
		public string Email { get; set; } = string.Empty;
		public string PhoneNumber { get; set; } = string.Empty;
		public string ShortRepresentAndSkills { get; set; } = string.Empty;
	}
}
