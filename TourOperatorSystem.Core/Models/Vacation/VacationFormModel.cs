using System.ComponentModel.DataAnnotations;
using TourOperatorSystem.Core.Contracts;
using TourOperatorSystem.Core.Models.Hotel;
using TourOperatorSystem.Core.Models.VacationCategory;
using static TourOperatorSystem.Core.Constants.MessageConstants;
using static TourOperatorSystem.Infrastructure.Constants.DataConstants;

namespace TourOperatorSystem.Core.Models.Vacation
{
    public class VacationFormModel : IVacationModel
	{
		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(VacationTitleMaxLength,
			MinimumLength = VacationTitleMinLength,
			ErrorMessage = LengthErrorMessage)]
		public string Title { get; set; } = null!;
		[Display(Name = "All inclusive ")]
		public bool? AllInclusive { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public decimal Price { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public int Capacity { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public bool IsActive { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		[Display(Name = "Enrollment Deadline date")]
		public string EnrollmentDeadline { get; set; } = null!;
		[Required(ErrorMessage = RequiredMessage)]
		[Display(Name = "Vacation start date")]
		public string StartDate { get; set; } = null!;
		[Required(ErrorMessage = RequiredMessage)]
		[Display(Name = "Vacation end date")]
		public string EndDate { get; set; } = null!;
		[Required(ErrorMessage = RequiredMessage)]
		public string Description { get; set; } = null!;
		[Required(ErrorMessage = RequiredMessage)]
		public string Location { get; set; } = null!;
		[Required(ErrorMessage = RequiredMessage)]
		public int AgentId { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public int VacationCategoryId { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public int HotelId { get; set; }
		public IEnumerable<VacationCategoryServiceModel> Categories = new List<VacationCategoryServiceModel>();
		public IEnumerable<HotelTypesServiceModel> Hotels = new List<HotelTypesServiceModel>();
	}
}
