using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOperatorSystem.Core.Models.Hotel
{
	public class AllHotelsServiceModel
	{
		public int HotelsPerPage { get; } = 3;

		public int CurrentPage { get; set; } = 1;

		public int TotalHotelCount { get; set; }
		public IEnumerable<HotelServiceModel> Hotels { get; set; } = new List<HotelServiceModel>();
	}
}
