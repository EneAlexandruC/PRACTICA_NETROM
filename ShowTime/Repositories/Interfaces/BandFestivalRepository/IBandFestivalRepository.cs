using ShowTime.Entities;

namespace ShowTime.Repositories.Interfaces.BandFestivalRepository
{
    public interface IBandFestivalRepository : IRepository<BandFestival>
    {
        Task<IEnumerable<Festival>> GetAllFestivalWithBandsInOrderAsync();
        Task<IEnumerable<BandFestival>> GetFestivalsByBandIdAsync(int bandId);
        Task<IEnumerable<BandFestival>> GetBandsByFestivalIdAsync(int festivalId);
        Task AddBandToFestivalAsync(int festivalId, int bandId, int orderNo);
        Task RemoveBandFromFestivalAsync(int festivalId, int bandId);
        Task UpdateBandOrderInFestivalAsync(int festivalId, int bandId, int newOrderNo);
        Task AddBandsToFestivalAsync(IEnumerable<BandFestival> bandFestival);
    }
}
