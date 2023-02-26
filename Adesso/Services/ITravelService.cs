using System;
using Adesso.Models;
using Adesso.DTOs;

namespace Adesso.Services
{
	public interface ITravelService	{
        Task<ResponseDto<TravelDto>> AddTravel(Travel newTravel);
        Task<ResponseDto<TravelDto>> UpdateTravelStatus(int travelId, bool isPublished);
        Task<ResponseDto<List<TravelDto>>> SearchTravels(string from, string to);
        Task RequestToJoinTravel(int travelId, int requestedSeats);
    }
}

