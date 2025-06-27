using ShowTime.Context;
using ShowTime.Entities;
using ShowTime.Repositories.Interfaces.BandRepository;

namespace ShowTime.Repositories.Implementation.BandRepository
{
    public class BandRepository(ShowTimeDbContext context) : Repository<Band>(context), IBandRepository
    {
    }
}