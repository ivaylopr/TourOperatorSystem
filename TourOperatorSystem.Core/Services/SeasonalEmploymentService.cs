using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TourOperatorSystem.Core.Contracts;
using TourOperatorSystem.Core.Models.SeasonalEmployment;
using TourOperatorSystem.Infrastructure.Constants;
using TourOperatorSystem.Infrastructure.Data.Common;
using TourOperatorSystem.Infrastructure.Data.Models;
using static TourOperatorSystem.Infrastructure.Constants.DataConstants;

namespace TourOperatorSystem.Core.Services
{
	public class SeasonalEmploymentService : ISeasonalEmploymentService
	{
		private readonly IRepository repository;
		public SeasonalEmploymentService(IRepository _repository)
		{
			repository = _repository;
		}



		//public Task<int> AddSeasonOffer(SeasonalOfferFormModel model)
		//{
		//	var offerToAdd = new SeasonalEmployment()
		//	{
		//		Title = model.Title,
		//		Description = model.Description,
		//		HourlyWage = model.HourlyWage,
		//		StartDate = model.StartDate,
		//	};
		//	int result = 1;
		//	return result;
		//}

		public async Task<AllOffersModel> AllAsync(int currentPage = 1, int offerPerPage = 1)
		{
			var offersResult = repository.AllReadOnly<SeasonalEmployment>().Where(s => s.IsActive == true);

			var offers = await offersResult
				.Skip((currentPage - 1) * offerPerPage)
				.Take(offerPerPage)
				.Select(s => new SeasonalServiceModel()
				{
					Id = s.Id,
					Title = s.Title,
					Description = s.Description,
					HourlyWage = s.HourlyWage,
					StartDate = s.StartDate.ToString(DataConstants.DateFormat),
					EndDate = s.EndDate.ToString(DataConstants.DateFormat),
					HotelId = s.HotelId,
					AgentId = s.AgentId,
					IsActive = s.IsActive
				}).ToListAsync();

			int totalOffersCount = await offersResult.CountAsync();

			return new AllOffersModel()
			{
				TotalOffersCount = totalOffersCount,
				SeasonalEmployments = offers
			};
		}

		public async Task<SeasonOfferDetailsViewModel> GetOfferDetailsByIdAsync(int id)
		{
			return await repository.AllReadOnly<SeasonalEmployment>().Where(s => s.Id == id)
				.Select(s => new SeasonOfferDetailsViewModel()
				{
					Title = s.Title,
					Description = s.Description,
					HourlyWage = s.HourlyWage,
					StartDate = s.StartDate.ToString(DataConstants.DateFormat),
					EndDate = s.EndDate.ToString(DataConstants.DateFormat),
					AgentPhoneNumber = s.Agent.PhoneNumber,
					Hotel = s.Hotel.Image != null ? $"data:image/png;base64,{Convert.ToBase64String(s.Hotel.Image)}" : null,
					HotelName = s.Hotel.Name,
					IsActive = s.IsActive
				}).FirstAsync();
		}

		public Task GetSeasonalOfferByIdAsync(int offerId, int applierId)
		{
			throw new NotImplementedException();
		}

		public async Task<bool> SeasonOfferExistByIdAsync(int id)
		{
			return await repository.AllReadOnly<SeasonalEmployment>().AnyAsync(s => s.Id == id);
		}

		async Task ISeasonalEmploymentService.AddNewCandidate(int offerId, int candidateId)
		{
			var offer = await repository.All<SeasonalEmployment>().FirstOrDefaultAsync(s => s.Id == offerId);
			var candidate = await repository.All<Candidate>().FirstOrDefaultAsync(s => s.Id == candidateId);
			if (offer != null && candidate != null)
			{
				offer.Applayers.Add(candidate);
				await repository.SaveChangesAsync();
			}
		}


	}
}
