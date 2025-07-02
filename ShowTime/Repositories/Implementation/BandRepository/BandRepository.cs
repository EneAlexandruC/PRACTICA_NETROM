using Microsoft.EntityFrameworkCore;
using ShowTime.Context;
using ShowTime.Entities;
using ShowTime.Enum;
using ShowTime.Repositories.Interfaces.BandRepository;

namespace ShowTime.Repositories.Implementation.BandRepository
{
    public class BandRepository(ShowTimeDbContext context) : Repository<Band>(context), IBandRepository
    {
        private readonly DbSet<Band> _dbset = context.Bands;

        public Task<IEnumerable<Band>> GetBandsByFestivalIdAsync(int festivalId)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Band>> GetBandsByGenreAsync(Genre genre)
        {
            return await _dbset
                .Where(b => b.Genre == genre)
                .ToListAsync();
        }

        public Task<IEnumerable<Band>> GetBandsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Band>> GetBandsWithFestivalsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsBandInFestivalAsync(int bandId, int festivalId)
        {
            throw new NotImplementedException();
        }
    }
}