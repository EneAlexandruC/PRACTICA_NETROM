using ShowTime.Entities;
using ShowTime.Enum;
using ShowTime.Repositories.Interfaces;
using ShowTime.Repositories.Interfaces.BookingRepository;
using ShowTime.Services.Interfaces.BookingService;

namespace ShowTime.Services.Implementation.BookingService
{
    public class BookingService(IBookingRepository repository) : Service<Booking>(repository), IBookingService
    {
        private readonly IBookingRepository _bookingRepository = repository;

        public async Task<IEnumerable<Booking>> GetBookingsByUserIdAsync(int userId)
        {
            return await _bookingRepository.GetBookingsByUserIdAsync(userId);
        }

        public async Task<Booking> CreateBookingAsync(int userId, int festivalId)
        {
            var booking = new Booking
            {
                ApplicationUserId = userId,
                FestivalId = festivalId,
                BookingDate = DateTime.UtcNow,
                Status = Status.Pending,
                Event = "Festival Booking"
            };

            await _bookingRepository.AddAsync(booking);
            await _bookingRepository.SaveChangesAsync();
            return booking;
        }

        public async Task<bool> HasUserBookedFestivalAsync(int userId, int festivalId)
        {
            return await _bookingRepository.HasUserBookedFestivalAsync(userId, festivalId);
        }

        public async Task<IEnumerable<Booking>> GetPendingBookingsByUserIdAsync(int userId)
        {
            return await _bookingRepository.GetPendingBookingsByUserIdAsync(userId);
        }

        public async Task ConfirmBookingAsync(int bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            if (booking != null)
            {
                booking.Status = Status.Confirmed;
                await _bookingRepository.UpdateAsync(booking);
                await _bookingRepository.SaveChangesAsync();
            }
        }

        public async Task CancelBookingAsync(int bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            if (booking != null)
            {
                booking.Status = Status.Cancelled;
                await _bookingRepository.UpdateAsync(booking);
                await _bookingRepository.SaveChangesAsync();
            }
        }

        public async Task DeleteBookingAsync(int bookingId)
        {
            var booking = await _bookingRepository.GetByIdAsync(bookingId);
            if (booking != null)
            {
                await _bookingRepository.DeleteAsync(booking);
                await _bookingRepository.SaveChangesAsync();
            }
        }
    }
}
