using ShowTime.Entities;
using ShowTime.Repositories.Implementation;
using ShowTime.Repositories.Interfaces;
using ShowTime.Repositories.Interfaces.FestivalRepository;
using ShowTime.Services.Interfaces.FestivalService;

namespace ShowTime.Services.Implementation.FestivalService
{
    public class FestivalService(IFestivalRepository repository) : Service<Festival>(repository), IFestivalService
    {
        public async Task AddFestivalBandAsync(int festivalId, int bandId)
        {
            if (festivalId <= 0)
                throw new ArgumentException("Festival ID must be greater than zero.", nameof(festivalId));
            if (bandId <= 0)
                throw new ArgumentException("Band ID must be greater than zero.", nameof(bandId));

            await repository.AddFestivalBandAsync(festivalId, bandId);
            await repository.SaveChangesAsync();
        }

        public async Task AddFestivalBandsAsync(int festivalId, IEnumerable<int> bandIds)
        {
            await repository.AddFestivalBandsAsync(festivalId, bandIds);
            await repository.SaveChangesAsync();
        }

        public async Task<IEnumerable<Festival>> GetFestivalsWithBandsAsync()
        {
            return await repository.GetFestivalsWithBandsAsync();
        }

        public async Task UpdateFestivalBandsAsync(int festivalId, IEnumerable<int> bandIds)
        {
            if (festivalId <= 0)
                throw new ArgumentException("Festival ID must be greater than zero.", nameof(festivalId));
            if (bandIds == null || !bandIds.Any())
                throw new ArgumentException("Band IDs cannot be null or empty.", nameof(bandIds));
            await repository.UpdateFestivalBandsAsync(festivalId, bandIds);
            await repository.SaveChangesAsync();
        }
    }
}
