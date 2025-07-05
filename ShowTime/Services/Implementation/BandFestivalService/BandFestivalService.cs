using ShowTime.Entities;
using ShowTime.Repositories.Interfaces.BandFestivalRepository;
using ShowTime.Services.Interfaces.BandFestivalService;

namespace ShowTime.Services.Implementation.BandFestivalService
{
    public class BandFestivalService(IBandFestivalRepository repository) : Service<BandFestival>(repository), IBandFestivalService
    {
        public async Task AddBandsToFestivalAsync(int festivalId, IEnumerable<int> bandsIds, IEnumerable<int> orderNos)
        {
            await repository.AddBandsToFestivalAsync(festivalId, bandsIds, orderNos);
            await repository.SaveChangesAsync();
        }

        public Task AddBandToFestivalAsync(int festivalId, int bandId, int orderNo)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Festival>> GetAllFestivalWithBandsInOrderAsync()
        {
            return await repository.GetAllFestivalWithBandsInOrderAsync();
        }

        public async Task<IEnumerable<BandFestival>> GetBandsByFestivalIdAsync(int festivalId)
        {
            if (festivalId < 0)
                throw new ArgumentOutOfRangeException(nameof(festivalId), "Festival ID must be a non-negative integer.");

            return await repository.GetBandsByFestivalIdAsync(festivalId);
        }

        public Task<IEnumerable<BandFestival>> GetFestivalsByBandIdAsync(int bandId)
        {
            throw new NotImplementedException();
        }

        public Task RemoveBandFromFestivalAsync(int festivalId, int bandId)
        {
            throw new NotImplementedException();
        }

        public Task UpdateBandOrderInFestivalAsync(int festivalId, int bandId, int newOrderNo)
        {
            throw new NotImplementedException();
        }
    }
}
