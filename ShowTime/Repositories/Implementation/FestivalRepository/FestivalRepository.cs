using Microsoft.EntityFrameworkCore;
using ShowTime.Context;
using ShowTime.Entities;
using ShowTime.Repositories.Interfaces.FestivalRepository;

namespace ShowTime.Repositories.Implementation.FestivalRepository
{
    public class FestivalRepository(ShowTimeDbContext context) : Repository<Festival>(context), IFestivalRepository
    {
        private readonly DbSet<Festival> _dbset = context.Festivals;

        public async Task AddFestivalBandAsync(int festivalId, int bandId)
        {
            var festival = await _dbset
                .Include(f => f.Bands)
                .FirstOrDefaultAsync(f => f.Id == festivalId);

            if (festival == null)
                throw new ArgumentException($"Festival with ID {festivalId} not found.");

            var band = await context.Bands.FindAsync(bandId);
            if (band == null)
                throw new ArgumentException($"Band with ID {bandId} not found.");

            if (!festival.Bands.Any(b => b.Id == bandId))
            {
                festival.Bands.Add(band);
            }
        }

        public async Task AddFestivalBandsAsync(int festivalId, IEnumerable<int> bandIds)
        {
            var festival = await _dbset
                .Include(f => f.Bands)
                .FirstOrDefaultAsync(f => f.Id == festivalId);

            if (festival == null)
                throw new ArgumentException($"Festival with ID {festivalId} not found.");

            if (bandIds == null || !bandIds.Any())
                return;

            // Get all requested bands in a single query
            var bandsToAdd = await context.Bands
                .Where(b => bandIds.Contains(b.Id))
                .ToListAsync();

            if (bandsToAdd.Count != bandIds.Distinct().Count())
            {
                var foundBandIds = bandsToAdd.Select(b => b.Id);
                var missingBandIds = bandIds.Except(foundBandIds);
                throw new ArgumentException($"Bands with IDs {string.Join(", ", missingBandIds)} not found.");
            }

            // Add only bands that aren't already in the festival
            foreach (var band in bandsToAdd)
            {
                if (!festival.Bands.Any(b => b.Id == band.Id))
                {
                    festival.Bands.Add(band);
                }
            }
        }

        public async Task<IEnumerable<Festival>> GetFestivalsWithBandsAsync()
        {
            return await _dbset
                .Include(f => f.Bands)
                .ToListAsync();
        }

        public Task<IEnumerable<Festival>> GetFestivalsByDateRangeAsync(DateTime startDate, DateTime endDate)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Festival>> GetFestivalsByLocationAsync(string location)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Festival>> GetFestivalsByNameAsync(string name)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Festival>> GetFestivalsWithBandsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<bool> IsFestivalActiveAsync(int festivalId)
        {
            throw new NotImplementedException();
        }
    }
}
