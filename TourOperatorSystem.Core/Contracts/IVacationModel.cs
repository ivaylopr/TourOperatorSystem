using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TourOperatorSystem.Core.Contracts
{
	public interface IVacationModel
	{
		public string Title { get; set; }
		public bool? AllInclusive { get; set; }
		public decimal Price { get; set; }
		public int Capacity { get; set; }
		public int VacationCategoryId { get; set; }
		public bool IsActive { get; set; }
		public string EnrollmentDeadline { get; set; }
		public string StartDate { get; set; }
		public string EndDate { get; set; }
		public string Description { get; set; }
		public string Location { get; set; }
	}
}
