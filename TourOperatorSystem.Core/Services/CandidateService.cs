using Microsoft.EntityFrameworkCore;
using TourOperatorSystem.Core.Contracts;
using TourOperatorSystem.Core.Models.Candidate;
using TourOperatorSystem.Infrastructure.Data.Common;
using TourOperatorSystem.Infrastructure.Data.Models;

namespace TourOperatorSystem.Core.Services
{
	public class CandidateService : ICandidateService
	{
		private readonly IRepository repository;
		public CandidateService(IRepository _repository)
		{
			repository = _repository;
		}



		public async Task<int> BecomeApplier(CandidateFormModel model, int offerId)
		{

			var applier = new Candidate()
			{
				Email = model.Email,
				PhoneNumber = model.PhoneNumber,
				IsAvaileble = true,
				UserId = model.UserId,
				SeasonalEmploymentId = offerId,
				ShortRepresentAndSkills = model.ShortRepresentAndSkills
			};
			await repository.AddAsync(applier);
			await repository.SaveChangesAsync();
			return applier.Id;
		}

		public async Task<bool> CandidateExistByIdAsync(int seasonalId, string userId)
		{
			var offer = await repository.AllReadOnly<SeasonalEmployment>().FirstAsync(s => s.Id == seasonalId);
			return offer.Applayers.Any(a => a.Id == seasonalId);
		}

		public async Task<bool> CandidateExistByIdAsync(int seasonalId)
		{
			return await repository.AllReadOnly<SeasonalEmployment>().AnyAsync(s => s.Id == seasonalId);
		}

		public async Task<IEnumerable<CandidateServiceModel>> GetAllCandidateAsync()
		{
			return await repository.AllReadOnly<Candidate>()
				.Select(c => new CandidateServiceModel()
				{
					Id = c.Id,
					Email = c.Email ?? string.Empty,
					PhoneNumber = c.PhoneNumber,
					ShortRepresentAndSkills = c.ShortRepresentAndSkills,
				}).ToListAsync();
		}

		public async Task<bool> UserAlreadyApllyiedAsync(string id)
		{
			return await repository.AllReadOnly<Candidate>().AnyAsync(c => c.UserId == id);
		}
	}
}
