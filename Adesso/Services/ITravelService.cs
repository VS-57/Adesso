using System;
using Adesso.Models;
using Adesso.DTOs;

namespace Adesso.Services
{
	public interface ITravelService	{
        Task<TravelDto> AddTravel(Travel newTravel);
        Task<TravelDto> UpdateTravelStatus(int travelId, bool isPublished);
        Task<List<TravelDto>> SearchTravels(string from, string to);
        Task RequestToJoinTravel(int travelId, int requestedSeats);
    }
}

