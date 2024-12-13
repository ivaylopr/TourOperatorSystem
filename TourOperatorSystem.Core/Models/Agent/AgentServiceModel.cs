using System.ComponentModel.DataAnnotations;
using static TourOperatorSystem.Infrastructure.Constants.DataConstants;
using static TourOperatorSystem.Core.Constants.MessageConstants;
using TourOperatorSystem.Core.Models.Comment;

namespace TourOperatorSystem.Core.Models.Agent
{
    public class AgentServiceModel
	{
		[Required(ErrorMessage = RequiredMessage)]
		public int Id { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		[Display(Name = "Phone number")]
		[StringLength(AgentPhoneNumberMaxLength,
			MinimumLength = AgentPhoneNumberMinLength,
			ErrorMessage = LengthErrorMessage)]
		public string PhoneNumber { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		public string Email { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		public bool IsActive { get; set; }
		[Required(ErrorMessage = RequiredMessage)]
		public string UserId { get; set; } = string.Empty;
		[Required(ErrorMessage = RequiredMessage)]
		public double Rating { get; set; }
		public IEnumerable<CommentServiceModel> Comments { get; set; } = new List<CommentServiceModel>();
	}
}
