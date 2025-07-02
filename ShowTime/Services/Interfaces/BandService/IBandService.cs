using ShowTime.Entities;
using ShowTime.Enum;

namespace ShowTime.Services.Interfaces.BandService
{
    public interface IBandService : IService<Band>
    {
        Task<IEnumerable<Band>> GetBandsByGenreAsync(Genre genre);
        Task<IEnumerable<Band>> GetBandsByFestivalIdAsync(int festivalId);
        Task<IEnumerable<Band>> GetBandsByNameAsync(string name);
        Task<IEnumerable<Band>> GetBandsWithFestivalsAsync();
        Task<bool> IsBandInFestivalAsync(int bandId, int festivalId);
    }
}
