namespace TourOperatorSystem.Core.Models.Vacation
{
    public class AllVacatinsServiceModel
	{
		public int VacatonsPerPage { get; } = 3;

		public int CurrentPage { get; set; } = 1;

		public int TotalVacationsCount { get; set; }
		public IEnumerable<VacationServiceModel> Vacations { get; set; } = new List<VacationServiceModel>();
	}
}
