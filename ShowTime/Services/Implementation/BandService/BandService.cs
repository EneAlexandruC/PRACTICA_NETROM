using ShowTime.Entities;
using ShowTime.Enum;
using ShowTime.Repositories.Implementation;
using ShowTime.Repositories.Interfaces.BandRepository;
using ShowTime.Services.Interfaces.BandService;

namespace ShowTime.Services.Implementation.BandService
{
    public class BandService(IBandRepository repository) : Service<Band>(repository), IBandService
    {
        public Task<IEnumerable<Band>> GetBandsByFestivalIdAsync(int festivalId)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Band>> GetBandsByGenreAsync(Genre genre)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Band>> GetBandsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Band>> GetBandsWithFestivalsAsync()
        {
            return await repository.GetBandsWithFestivalsAsync();
        }

        public Task<bool> IsBandInFestivalAsync(int bandId, int festivalId)
        {
            throw new NotImplementedException();
        }
    }
}
