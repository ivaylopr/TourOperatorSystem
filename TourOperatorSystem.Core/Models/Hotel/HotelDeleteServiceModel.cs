using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOperatorSystem.Core.Contracts;

namespace TourOperatorSystem.Core.Models.Hotel
{
	public class HotelDeleteServiceModel : IHotelModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string Location { get; set; } = string.Empty;
		public int CategoryStars { get; set; }
	}

}
