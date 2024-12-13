using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOperatorSystem.Core.Contracts;

namespace TourOperatorSystem.Core.Models.Hotel
{
	public class HotelDetailsServiceModel : IHotelModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public int CategoryStars { get; set; }
		public string HotelReview { get; set; } = string.Empty;
		public bool Spa { get; set; }
		public bool Pool { get; set; }
		public bool ChildrenAnimators { get; set; }
		public decimal? AllInclusivePrice { get; set; }
		public string Location { get; set; } = string.Empty;
		public double? Rating { get; set; }
		public string Image { get; set; } = string.Empty;
	}
}
