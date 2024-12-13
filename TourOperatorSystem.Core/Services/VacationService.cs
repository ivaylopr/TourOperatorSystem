using Microsoft.EntityFrameworkCore;
using TourOperatorSystem.Core.Contracts;
using TourOperatorSystem.Core.Models.Vacation;
using TourOperatorSystem.Infrastructure.Constants;
using TourOperatorSystem.Infrastructure.Data.Common;
using TourOperatorSystem.Infrastructure.Data.Models;

namespace TourOperatorSystem.Core.Services
{
	public class VacationService : IVacationService
	{
		private readonly IRepository repository;
		public VacationService(IRepository _repository)
		{
			repository = _repository;
		}

		public async Task<AllVacatinsServiceModel> AllAsync(int currentPage = 1
			, int vacationPerPage = 1)
		{


			var vacationResult = await repository.AllReadOnly<Vacation>()
				.ToListAsync();
			foreach (var item in vacationResult)
			{
				if (DateTime.Now > item.EnrollmentDeadline)
				{
					var expired = await repository.All<Vacation>().FirstAsync(v => v.Id == item.Id);
					expired.IsActive = false;
					await repository.SaveChangesAsync();
				}
			}

			var vacations = await repository.AllReadOnly<Vacation>()
				.Where(vacation => vacation.IsActive == true)
				.Skip((currentPage - 1) * vacationPerPage)
				.Take(vacationPerPage)
				.Select(v => new VacationServiceModel()
				{
					Id = v.Id,
					Title = v.Title,
					AllInclusive = v.AllInclusive ?? false,
					Price = v.Price,
					Capacity = v.Capacity,
					VacationCategoryId = v.VacationCategoryId,
					VacationType = v.VacationCategory.VacationType,
					IsActive = v.IsActive,
					EnrollmentDeadline = v.EnrollmentDeadline.ToString(DataConstants.DateFormat),
					StartDate = v.StartDate.ToString(DataConstants.DateFormat),
					EndDate = v.EndDate.ToString(DataConstants.DateFormat),
					Description = v.Description,
					Location = v.Location,
					AgentEmail = v.Agent.User.Email,
					AgentPhoneNumber = v.Agent.PhoneNumber,
					HotelName = v.Hotel.Name,
					HotelImage = v.Hotel.Image
				})
				.ToListAsync();
			var activeVacationResult = await repository.AllReadOnly<Vacation>().Where(v => v.IsActive == true).CountAsync();
			int totalVacations = activeVacationResult;

			return new AllVacatinsServiceModel()
			{
				TotalVacationsCount = totalVacations,
				Vacations = vacations
			};
		}

		public async Task<IEnumerable<string>> AllCategoriesNamesAsync()
		{
			return await repository
				.AllReadOnly<VacationCategory>()
				.Select(vc => vc.VacationType)
				.Distinct()
				.ToListAsync();
		}

		public string CategoryNameByIdAsync(int id)
		{
			return repository.AllReadOnly<VacationCategory>()
				.Where(vc => vc.Id == id)
				.Select(vc => vc.VacationType.ToString())
				.First();
		}

		public async Task<int> CreateVacationAsync(
			VacationFormModel model,
			DateTime enrollmentDate,
			DateTime startDate,
			DateTime endDate)
		{
			Vacation vacation = new Vacation()
			{
				Title = model.Title,
				AllInclusive = model.AllInclusive,
				Price = model.Price,
				Capacity = model.Capacity,
				IsActive = model.IsActive,
				EnrollmentDeadline = enrollmentDate,
				StartDate = startDate,
				EndDate = endDate,
				Description = model.Description,
				Location = model.Location,
				AgentId = (int)model.AgentId,
				VacationCategoryId = model.VacationCategoryId,
				HotelId = model.HotelId
			};
			await repository.AddAsync(vacation);
			await repository.SaveChangesAsync();
			return vacation.Id;
		}

		public async Task<VacationFormModel> GetVacationByIdAsync(int id)
		{

			return await repository.AllReadOnly<Vacation>()
				.Where(v => v.Id == id)
				.Select(v => new VacationFormModel()
				{
					Title = v.Title,
					AllInclusive = v.AllInclusive,
					Price = v.Price,
					Capacity = v.Capacity,
					IsActive = v.IsActive,
					EnrollmentDeadline = v.EnrollmentDeadline.ToString(DataConstants.DateFormat),
					StartDate = v.StartDate.ToString(DataConstants.DateFormat),
					EndDate = v.EndDate.ToString(DataConstants.DateFormat),
					Description = v.Description,
					Location = v.Location,
					AgentId = v.AgentId,
					VacationCategoryId = v.VacationCategoryId,
					HotelId = v.HotelId
				}).FirstAsync();
		}

		public async Task<VacationServiceModel?> GetVacationDetailsByIdAsync(int id)
		{

			return await repository.AllReadOnly<Vacation>().Where(v => v.Id == id)
				.Select(v => new VacationServiceModel()
				{
					Id = v.Id,
					Title = v.Title,
					AllInclusive = v.AllInclusive ?? false,
					Price = v.Price,
					Capacity = v.Capacity,
					VacationCategoryId = v.VacationCategoryId,
					VacationType = v.VacationCategory.VacationType,
					IsActive = v.IsActive,
					EnrollmentDeadline = v.EnrollmentDeadline.ToString(DataConstants.DateFormat),
					StartDate = v.StartDate.ToString(DataConstants.DateFormat),
					EndDate = v.EndDate.ToString(DataConstants.DateFormat),
					Description = v.Description,
					Location = v.Location,
					AgentEmail = v.Agent.User.Email,
					AgentPhoneNumber = v.Agent.PhoneNumber,
					HotelName = v.Hotel.Name,
					HotelImage = v.Hotel.Image
				}).FirstOrDefaultAsync();
		}

		public async Task<bool> IsInVacationUserById(string id, int vacationId)
		{
			return await repository.AllReadOnly<VacationCustomer>()
				.AnyAsync(vc => vc.VacationId == vacationId && vc.UserId == id);
		}

		public async Task<AllVacatinsServiceModel> JoinedByUserIdAsync(
			string id,
			int currentPage = 1,
			int totalModelsCount = 1)
		{
			var vacations = await repository.AllReadOnly<VacationCustomer>()
				.Where(vc => vc.UserId == id)
				.Skip((currentPage - 1) * totalModelsCount)
				.Take(totalModelsCount)
				.Select(vc => new VacationServiceModel()
				{
					Id = vc.VacationId,
					Title = vc.Vacation.Title,
					AllInclusive = vc.Vacation.AllInclusive ?? false,
					Price = vc.Vacation.Price,
					Capacity = vc.Vacation.Capacity,
					VacationCategoryId = vc.Vacation.VacationCategoryId,
					VacationType = vc.Vacation.VacationCategory.VacationType,
					IsActive = vc.Vacation.IsActive,
					EnrollmentDeadline = vc.Vacation.EnrollmentDeadline.ToString(DataConstants.DateFormat),
					StartDate = vc.Vacation.StartDate.ToString(DataConstants.DateFormat),
					EndDate = vc.Vacation.EndDate.ToString(DataConstants.DateFormat),
					Description = vc.Vacation.Description,
					Location = vc.Vacation.Location,
					AgentEmail = vc.Vacation.Agent.User.Email,
					AgentPhoneNumber = vc.Vacation.Agent.PhoneNumber,
					HotelName = vc.Vacation.Hotel.Name,
					HotelImage = vc.Vacation.Hotel.Image

				}).ToListAsync();
			int totalVacationsCount = await repository.AllReadOnly<VacationCustomer>()
				.Where(vc => vc.UserId == id && vc.Vacation.IsActive == true).CountAsync();
			return new AllVacatinsServiceModel()
			{
				TotalVacationsCount = totalVacationsCount,
				Vacations = vacations
			};

		}

		public async Task JoinVacationAsync(int id, string userId)
		{
			var vacationToJoin = await repository.All<Vacation>().FirstAsync(v => v.Id == id);
			VacationCustomer vacationCustomerToJoin = new VacationCustomer() { VacationId = id, UserId = userId };
			vacationToJoin.VacationCustomers.Add(vacationCustomerToJoin);
			await repository.SaveChangesAsync();
		}

		public async Task<bool> VacationExistByIdAsync(int id)
		{
			return await repository.AllReadOnly<Vacation>().AnyAsync(v => v.Id == id);
		}
	}
}
