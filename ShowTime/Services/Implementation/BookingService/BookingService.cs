using ShowTime.Entities;
using ShowTime.Repositories.Interfaces;
using ShowTime.Repositories.Interfaces.BookingRepository;
using ShowTime.Services.Interfaces.BookingService;

namespace ShowTime.Services.Implementation.BookingService
{
    public class BookingService(IBookingRepository repository) : Service<Booking>(repository), IBookingService
    {
    }
}
