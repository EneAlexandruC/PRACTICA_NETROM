using ShowTime.Context;
using ShowTime.Entities;
using ShowTime.Repositories.Interfaces.BookingRepository;

namespace ShowTime.Repositories.Implementation.BookingRepository
{
    public class BookingRepository(ShowTimeDbContext context) : Repository<Booking>(context), IBookingRepository
    {
    }
}
