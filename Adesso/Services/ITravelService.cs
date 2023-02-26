using System;
using Adesso.Models;

namespace Adesso.Services
{
	public interface ITravelService	{
        Task<Travel> AddTravel(Travel newTravel);
        Task<Travel> UpdateTravelStatus(int travelId, bool isPublished);
        Task<List<Travel>> SearchTravels(string from, string to);
        Task RequestToJoinTravel(int travelId, int requestedSeats);
    }
}

