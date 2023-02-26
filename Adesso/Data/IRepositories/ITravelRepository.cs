using Adesso.Models;

namespace Adesso.Data.IRepositories
{
    public interface ITravelRepository : IGenericRepository<Travel>
    {
        Task<List<Travel>> SearchTravels(string from, string to);
    }
}