using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOperatorSystem.Core.Models.Room
{
	public class RoomServiceModel
	{
		public int Id { get; set; }
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
		public string HotelName { get; set; } = string.Empty;


	}
}
