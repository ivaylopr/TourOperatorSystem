using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TourOperatorSystem.Infrastructure.Constants.DataConstants;

namespace TourOperatorSystem.Infrastructure.Data.Models
{
    [Comment("Agent class")]
    public class Agent
    {
        [Key]
        [Comment("Agent identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(AgentPhoneNumberMaxLength)]
        [Comment("Agent phone number")]
        public string PhoneNumber { get; set; } = string.Empty;
        [Required]
        [Comment("User who is agent identifier")]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
        [Required]
        public bool IsActive { get; set; }
        [Comment("Rating of the agent")]
        public double? Rating { get; set; }
        public IEnumerable<Comment> Comments { get; set; } = new List<Comment>();
    }
}
