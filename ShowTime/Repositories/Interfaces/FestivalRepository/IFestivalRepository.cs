using ShowTime.Entities;

namespace ShowTime.Repositories.Interfaces.FestivalRepository
{
    public interface IFestivalRepository : IRepository<Festival>
    {

        Task UpdateFestivalBandsAsync(int festivalId, IEnumerable<int> bandIds);
        Task AddFestivalBandsAsync(int festivalId, IEnumerable<int> bandIds);
        Task AddFestivalBandAsync(int festivalId, int bandId);
        Task<IEnumerable<Festival>> GetFestivalsByLocationAsync(string location);
        Task<IEnumerable<Festival>> GetFestivalsByDateRangeAsync(DateTime startDate, DateTime endDate);
        Task<IEnumerable<Festival>> GetFestivalsWithBandsAsync();
        Task<bool> IsFestivalActiveAsync(int festivalId);
        Task<IEnumerable<Festival>> GetFestivalsByNameAsync(string name);
    }
}
