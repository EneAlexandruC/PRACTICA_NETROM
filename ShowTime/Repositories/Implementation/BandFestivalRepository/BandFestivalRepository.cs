using Microsoft.EntityFrameworkCore;
using ShowTime.Context;
using ShowTime.Entities;
using ShowTime.Repositories.Interfaces.BandFestivalRepository;

namespace ShowTime.Repositories.Implementation.BandFestivalRepository
{
    public class BandFestivalRepository(ShowTimeDbContext context) : Repository<BandFestival>(context), IBandFestivalRepository
    {
        public async Task AddBandToFestivalAsync(IEnumerable<BandFestival> bandFestivals)
        {
            foreach (var bandFestival in bandFestivals)
            {
                await Context.BandFestivals.AddAsync(bandFestival);
            }
            await Context.SaveChangesAsync();
        }

        public Task AddBandToFestivalAsync(int festivalId, int bandId, int orderNo)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Festival>> GetAllFestivalWithBandsInOrderAsync()
        {
            var bandFestivals = await Context.BandFestivals
                .Include(bf => bf.Band)
                .Include(bf => bf.Festival)
                .ToListAsync();

            var orderedFestivals = bandFestivals.OrderBy(x => x.OrderNo).Select(x => x.Festival);

            return orderedFestivals;
        }

        public async Task<IEnumerable<BandFestival>> GetBandsByFestivalIdAsync(int festivalId)
        {
            return await Context.BandFestivals
                .Where(bf => bf.FestivalId == festivalId)
                .OrderBy(bf => bf.OrderNo)
                .ToListAsync();
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

        public Task UpdateBandOrderInFestivalAsync(IEnumerable<BandFestival> bandFestivals)
        {
            throw new NotImplementedException();
        }
    }
}
