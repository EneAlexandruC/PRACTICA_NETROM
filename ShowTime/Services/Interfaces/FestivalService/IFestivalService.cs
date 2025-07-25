﻿using ShowTime.Entities;

namespace ShowTime.Services.Interfaces.FestivalService
{
    public interface IFestivalService : IService<Festival>
    {
        Task AddFestivalBandAsync(int festivalId, int bandId);
        Task AddFestivalBandsAsync(int festivalId, IEnumerable<int> bandIds);
        Task UpdateFestivalBandsAsync(int festivalId, IEnumerable<int> bandIds);
        Task<IEnumerable<Festival>> GetFestivalsWithBandsAsync();
        Task<IEnumerable<Festival>> GetFestivalsWithBookingsAsync();
    }
}
