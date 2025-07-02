using ShowTime.Entities;
using ShowTime.Enum;

namespace ShowTime.Repositories.Interfaces.BandRepository
{
    public interface IBandRepository : IRepository<Band>
    {
        Task<IEnumerable<Band>> GetBandsByGenreAsync(Genre genre);
        Task<IEnumerable<Band>> GetBandsByFestivalIdAsync(int festivalId);
        Task<IEnumerable<Band>> GetBandsByNameAsync(string name);
        Task<IEnumerable<Band>> GetBandsWithFestivalsAsync();
        Task<bool> IsBandInFestivalAsync(int bandId, int festivalId);
    }
}
