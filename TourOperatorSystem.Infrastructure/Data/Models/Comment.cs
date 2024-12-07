using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TourOperatorSystem.Infrastructure.Constants.DataConstants;

namespace TourOperatorSystem.Infrastructure.Data.Models
{
    [Comment("Class for comments and reviews by the users")]
    public class Comment
    {
        [Key]
        [Comment("Comment identifier")]
        public int Id { get; set; }
        [Required]
        [MaxLength(CommentReviewMaxLength)]
        [Comment("Review for the hotel or for the agent")]
        public string Review { get; set; } = string.Empty;
        [Required]
        [Comment("User who give the review")]
        public string UserId { get; set; } = string.Empty;
        [ForeignKey(nameof(UserId))]
        public IdentityUser User { get; set; } = null!;
        [Comment("Rating given by the user creator of the review")]
        public int? Rating { get; set; }
    }
}
