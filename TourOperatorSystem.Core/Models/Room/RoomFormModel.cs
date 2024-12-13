using System.ComponentModel.DataAnnotations;
using static TourOperatorSystem.Core.Constants.MessageConstants;
using static TourOperatorSystem.Infrastructure.Constants.DataConstants;

namespace TourOperatorSystem.Core.Models.Room
{
    public class RoomFormModel
	{
		[Required]
		[StringLength(RoomTitleMaxLength,
			MinimumLength = RoomTitleMinLength,
			ErrorMessage = LengthErrorMessage)]
		public string Title { get; set; } = string.Empty;
		[StringLength(RoomDescriptionMaxLenght,
			MinimumLength = RoomDescriptionMinLenght,
			ErrorMessage = LengthErrorMessage)]
		public string? Description { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public decimal Price { get; set; }
		[MaxLength(RoomAddExtrasMaxLength)]
		public string? AdditionalExtras { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public int Count { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public int HotelId { get; set; }
	}
}
