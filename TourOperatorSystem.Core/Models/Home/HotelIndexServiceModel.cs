namespace TourOperatorSystem.Core.Models.Home
{
    public class HotelIndexServiceModel
	{
		public int Id { get; set; }
		public string Name { get; set; } = string.Empty;
		public string HotelPreview { get; set; } = string.Empty;
		public string? Image { get; set; } = string.Empty;
		public double? Rating { get; set; }
	}
}
