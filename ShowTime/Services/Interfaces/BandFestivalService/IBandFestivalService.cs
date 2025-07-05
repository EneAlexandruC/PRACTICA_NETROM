using ShowTime.Entities;

namespace ShowTime.Services.Interfaces.BandFestivalService
{
    public interface IBandFestivalService : IService<BandFestival>
    {
        Task<IEnumerable<BandFestival>> GetFestivalsByBandIdAsync(int bandId);
        Task<IEnumerable<BandFestival>> GetBandsByFestivalIdAsync(int festivalId);
        Task AddBandToFestivalAsync(int festivalId, int bandId, int orderNo);
        Task RemoveBandFromFestivalAsync(int festivalId, int bandId);
        Task UpdateBandOrderInFestivalAsync(int festivalId, int bandId, int newOrderNo);
        Task<IEnumerable<Festival>> GetAllFestivalWithBandsInOrderAsync();
        Task AddBandsToFestivalAsync(int festivalId, IEnumerable<int> bandsIds, IEnumerable<int> orderNos);
    }
}
