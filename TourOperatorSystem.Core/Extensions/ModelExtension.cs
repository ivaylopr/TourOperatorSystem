using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TourOperatorSystem.Core.Contracts;

namespace TourOperatorSystem.Core.Extensions
{
	public static class ModelExtensions
	{
		public static string GetInfo(this IHotelModel hotel)
		{
			string info = hotel.Name.Replace(" ", "-") + GetLocation(hotel.Location);
			info = Regex.Replace(info, @"[^a-zA-Z0-9\-]", string.Empty);

			return info;
		}

		private static string GetLocation(string location)
		{
			location = string.Join("-", location.Split(" ").Take(3));

			return location;
		}
	}
}
