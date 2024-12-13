using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOperatorSystem.Core.Models.SeasonalEmployment
{
	public class AllOffersModel
	{
		public int OfferPerPage { get; } = 3;
		public int CurrentPage { get; init; } = 1;
		public int TotalOffersCount { get; set; }
		public IEnumerable<SeasonalServiceModel> SeasonalEmployments { get; set; } = new List<SeasonalServiceModel>();
	}
}
