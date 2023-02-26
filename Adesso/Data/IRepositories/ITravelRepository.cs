using Adesso.Models;

namespace Adesso.Data.IRepositories
{
    public interface ITravelRepository
    {
        Task<Travel> AddTravel(Travel newTravel);
        Task UpdateTravel(Travel travel);
        Task<List<Travel>> SearchTravels(string from, string to);
        Task<Travel> GetTravelById(int travelId);
    }
}