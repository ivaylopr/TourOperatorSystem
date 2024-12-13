using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOperatorSystem.Core.Contracts;

namespace TourOperatorSystem.Core.Models.Hotel
{
	public class EditHotelFormModel : IHotelModel
	{
		[Required(ErrorMessage = RequiredMessage)]
		public int Id { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(HotelNameMaxLength,
			MinimumLength = HotelNameMinLength,
			ErrorMessage = LengthErrorMessage)]
		public string Name { get; set; } = null!;
		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(HotelReviewMaxLength,
			MinimumLength = HotelReviewMinLength,
			ErrorMessage = LengthErrorMessage)]
		public string HotelReview { get; set; } = null!;
		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(HotelLocationMaxLength,
			MinimumLength = HotelLocationMinLength,
			ErrorMessage = LengthErrorMessage)]
		public string Location { get; set; } = null!;
		[Required(ErrorMessage = RequiredMessage)]
		public bool Spa { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public bool Pool { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public bool ChildrenAnimators { get; set; }
		public decimal? AllInclusivePrice { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public int Capacity { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public int CategoryStars { get; set; }
		public double? Rating { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public string Image { get; set; } = string.Empty;
		[Display(Name = "Vacation category")]
		public int VacationCategoryId { get; set; }
		public IEnumerable<VacationCategoryServiceModel> VacationCategories { get; set; } = new List<VacationCategoryServiceModel>();
	}
}
