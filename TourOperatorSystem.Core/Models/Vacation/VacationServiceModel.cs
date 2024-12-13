namespace TourOperatorSystem.Core.Models.Vacation
{
	public class VacationServiceModel : IVacationModel
	{
		[Required(ErrorMessage = RequiredMessage)]
		public int Id { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		[StringLength(VacationTitleMaxLength,
			MinimumLength = VacationTitleMinLength,
			ErrorMessage = LengthErrorMessage)]
		public string Title { get; set; } = string.Empty;
		public bool? AllInclusive { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public decimal Price { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public int Capacity { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public int VacationCategoryId { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public string VacationType { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		public bool IsActive { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public string EnrollmentDeadline { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		public string StartDate { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		public string EndDate { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		public string Description { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		public string Location { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		public string AgentEmail { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		public string AgentPhoneNumber { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		public string HotelName { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		public string HotelImage { get; set; } = string.Empty;


	}
}
