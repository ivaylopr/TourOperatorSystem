using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOperatorSystem.Core.Contracts;

namespace TourOperatorSystem.Core.Models.Hotel
{
	public class HotelServiceModel : IHotelModel
	{
		[Required(ErrorMessage = RequiredMessage)]
		public int Id { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(HotelNameMaxLength,
			MinimumLength = HotelNameMinLength,
			ErrorMessage = LengthErrorMessage)]
		public string Name { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(HotelLocationMaxLength,
			MinimumLength = HotelLocationMinLength,
			ErrorMessage = LengthErrorMessage)]
		public string Location { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		public string Image { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		public string VacationType { get; set; } = string.Empty;
		public decimal? AllInclusivePrice { get; set; }
		public IEnumerable<VacationCategoryServiceModel> VacationsCategories { get; set; } = new List<VacationCategoryServiceModel>();
	}
}
