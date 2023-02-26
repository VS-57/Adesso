using System;
using Adesso.DTOs;
using Adesso.Models;

namespace Adesso.Services.validation
{
	public interface IRequestValidator
	{
        Task<Boolean> ValidateAddTravel(Travel newTravel);
        Task<Boolean> ValidateUpdateTravelStatus(int travelId, bool isPublished);
        Task<Boolean> ValidateSearchTravels(string from, string to);
        Task<Boolean> ValidateRequestToJoinTravel(int travelId, int requestedSeats);


    }
}

