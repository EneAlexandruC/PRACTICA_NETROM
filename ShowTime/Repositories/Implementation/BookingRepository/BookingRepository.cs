using Microsoft.EntityFrameworkCore;
using ShowTime.Context;
using ShowTime.Entities;
using ShowTime.Repositories.Interfaces.BookingRepository;

namespace ShowTime.Repositories.Implementation.BookingRepository
{
    public class BookingRepository(ShowTimeDbContext context) : Repository<Booking>(context), IBookingRepository
    {
        private readonly DbSet<Booking> _dbSet = context.Bookings;

        public async Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(b => b.ApplicationUserId == userId)
                .Include(b => b.Festival)
                .OrderByDescending(b => b.BookingDate)
                .ToListAsync();
        }

        public async Task<bool> HasUserBookedFestivalAsync(int userId, int festivalId)
        {
            return await _dbSet
                .AnyAsync(b => b.ApplicationUserId == userId && b.FestivalId == festivalId);
        }

        public async Task<IEnumerable<Booking>> GetPendingBookingsByUserIdAsync(int userId)
        {
            return await _dbSet
                .Where(b => b.ApplicationUserId == userId && b.Status == ShowTime.Enum.Status.Pending)
                .Include(b => b.Festival)
                .OrderByDescending(b => b.BookingDate)
                .ToListAsync();
        }

        public async Task<IEnumerable<Booking>> GetBookingsWithFestivalDetailsAsync(int userId)
        {
            return await _dbSet
                .Where(b => b.ApplicationUserId == userId)
                .Include(b => b.Festival)
                .ThenInclude(f => f!.Bands)
                .OrderByDescending(b => b.BookingDate)
                .ToListAsync();
        }
    }
}
