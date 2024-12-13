using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using TourOperatorSystem.Core.Contracts;
using TourOperatorSystem.Core.Models.VacationCategory;
using static TourOperatorSystem.Core.Constants.MessageConstants;
using static TourOperatorSystem.Infrastructure.Constants.DataConstants;

namespace TourOperatorSystem.Core.Models.Hotel
{
	public class HotelFormModel : IHotelModel
	{
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
		[Display(Name = "Spa availeble")]
		public bool Spa { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		[Display(Name = "Pool availeble")]
		public bool Pool { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		[Display(Name = "Children animators availeble")]
		public bool ChildrenAnimators { get; set; }
		[Display(Name = "All inclusice price")]
		public decimal? AllInclusivePrice { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public int Capacity { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public int CategoryStars { get; set; }
		public double? Rating { get; set; }
        [Required(ErrorMessage = RequiredMessage)]
        [Display(Name = "Image")]
        public IFormFile? Image { get; set; } = null!;
        [Required(ErrorMessage = RequiredMessage)]
		[Display(Name = "Vacation category")]
		public int VacationCategoryId { get; set; }
		public IEnumerable<VacationCategoryServiceModel> VacationCategories { get; set; } = new List<VacationCategoryServiceModel>();

	}
}
