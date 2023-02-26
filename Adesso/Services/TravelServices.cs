using Adesso.Data.IRepositories;
using Adesso.Models;

namespace Adesso.Services
{
    public class TravelService : ITravelService

    {
        private readonly ITravelRepository _travelRepository;

        public TravelService(ITravelRepository travelRepository)
        {
            _travelRepository = travelRepository;
        }

        public async Task<Travel> AddTravel(Travel newTravel)
        {
            if (newTravel == null)
            {
                throw new ArgumentNullException(nameof(newTravel));
            }

            newTravel.isPublished = false; // Travels are not published by default

            await _travelRepository.Create(newTravel);

            return newTravel;
        }

        public async Task<Travel> UpdateTravelStatus(int travelId, bool isPublished)
        {
            var travel = await _travelRepository.GetById(travelId);

            if (travel == null)
            {
                throw new Exception("The specified travel could not be found");
            }

            travel.isPublished = isPublished;

            await _travelRepository.Update(travel);

            return travel;
        }

        public async Task<List<Travel>> SearchTravels(string from, string to)
        {
            var travels = await _travelRepository.SearchTravels(from, to);

            return travels;
        }

        public async Task RequestToJoinTravel(int travelId, int requestedSeats)
        {
            var travel = await _travelRepository.GetById(travelId);

            if (travel == null)
            {
                throw new Exception("The specified travel could not be found");
            }

            if (travel.AvailableSeats < requestedSeats)
            {
                throw new Exception("The requested seat count is greater than the available seats");
            }

            // Update available seats count
            travel.AvailableSeats -= requestedSeats;

            await _travelRepository.Update(travel);
        }
    }
}
