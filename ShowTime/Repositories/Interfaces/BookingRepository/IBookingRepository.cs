using ShowTime.Entities;

namespace ShowTime.Repositories.Interfaces.BookingRepository
{
    public interface IBookingRepository : IRepository<Booking>
    {
        Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId);
        Task<bool> HasUserBookedFestivalAsync(int userId, int festivalId);
        Task<IEnumerable<Booking>> GetPendingBookingsByUserIdAsync(int userId);
        Task<IEnumerable<Booking>> GetBookingsWithFestivalDetailsAsync(int userId);
    }
}
