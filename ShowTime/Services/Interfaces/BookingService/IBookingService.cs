using ShowTime.Entities;

namespace ShowTime.Services.Interfaces.BookingService
{
    public interface IBookingService: IService<Booking>
    {
        Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId);
        Task<Booking> CreateBookingAsync(int userId, int festivalId);
        Task<bool> HasUserBookedFestivalAsync(int userId, int festivalId);
        Task<IEnumerable<Booking>> GetPendingBookingsByUserIdAsync(int userId);
        Task ConfirmBookingAsync(int bookingId);
        Task CancelBookingAsync(int bookingId);
        Task DeleteBookingAsync(int bookingId);
    }
}
