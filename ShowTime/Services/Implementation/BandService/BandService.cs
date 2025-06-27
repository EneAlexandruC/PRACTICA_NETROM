using ShowTime.Context;
using ShowTime.Entities;
using ShowTime.Repositories.Interfaces;
using ShowTime.Services.Interfaces;
using ShowTime.Services.Interfaces.BandService;

namespace ShowTime.Services.Implementation.BandService
{
    public class BandService(IRepository<Band> repository) : Service<Band>(repository), IBandService
    {
    }
}
