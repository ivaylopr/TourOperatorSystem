using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static TourOperatorSystem.Infrastructure.Constants.DataConstants;

namespace TourOperatorSystem.Infrastructure.Data.Models
{

    [Comment("Hotel class")]
        public class Hotel
        {
            [Key]
            [Comment("Hotel identifier")]
            public int Id { get; set; }
            [Required]
            [MaxLength(HotelNameMaxLength)]
            [Comment("Hotel name")]
            public string Name { get; set; } = string.Empty;
            [Required]
            [MaxLength(HotelReviewMaxLength)]
            [Comment("Hotel review and presentation")]
            public string HotelReview { get; set; } = string.Empty;
            [Required]
            [Comment("Spa available")]
            public bool Spa { get; set; }
            [Required]
            [Comment("Pool available")]
            public bool Pool { get; set; }
            [Comment("All inclusive additional price to the room offer")]
            public decimal? AllInclusivePrice { get; set; }
            [Required]
            [Comment("Children animation available")]
            public bool ChildrenAnimators { get; set; }
            [Required]
            [MaxLength(HotelLocationMaxLength)]
            [Comment("Hotel location")]
            public string Location { get; set; } = string.Empty;
            [Required]
            [Comment("Hotel Total capacity")]
            public int Capacity { get; set; }
            [Required]
            [Comment("Category stars of the hotel")]
            public int CategoryStars { get; set; }
            [Comment("Rating of the hotel")]
            public double? Rating { get; set; }
            [Required]
            public byte[] Image { get; set; } = Array.Empty<byte>();

            [Required]
            public int VacationCategoryId { get; set; }
            [ForeignKey(nameof(VacationCategoryId))]
            public VacationCategory VacationCategory { get; set; } = null!;
            public IList<Comment> Comments { get; set; } = new List<Comment>();
            public IEnumerable<HotelRoom> HotelRooms { get; set; } = new List<HotelRoom>();
            public IList<HotelVacation> HotelVacations { get; set; } = new List<HotelVacation>();
            
    }
    }

