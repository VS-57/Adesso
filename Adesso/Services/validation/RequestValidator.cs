using System;
using Adesso.Models;

namespace Adesso.Services.validation
{
	public class RequestValidator: IRequestValidator
	{
		public RequestValidator()
		{
		}

        public Task<bool> ValidateAddTravel(Travel newTravel)
        {
            IdNullCheck(newTravel.Id);
            DirectionNullCheck(newTravel.From,newTravel.Destination);
            SeatCountMustNotBeZero(newTravel);
            return Task.FromResult(true);
        }

        public Task<bool> ValidateRequestToJoinTravel(int travelId, int requestedSeats)
        {
            IdCheck(travelId);
            RequestedSeatNullCheck(requestedSeats);
            return Task.FromResult(true);
        }

        public Task<bool> ValidateSearchTravels(string from, string to)
        {
            DirectionNullCheck(from,to);
            return Task.FromResult(true);
        }

        public Task<bool> ValidateUpdateTravelStatus(int travelId, bool isPublished)
        {
            IdCheck(travelId);
            return Task.FromResult(true);
        }

        private static void SeatCountMustNotBeZero(Travel newTravel)
        {
            if (newTravel.SeatCount <= 0)
            {
                throw new Exception("Seat cant be null nor bellow zero");
            }
        }

        private static void IdCheck(int newTravelId)
        {
            if (newTravelId == 0)
            {
                throw new Exception("Id Must Not Be Null");
            }
        }

        private static void IdNullCheck(int newTravelId)
        {
            if (newTravelId != 0)
            {
                throw new Exception("Id Must Be Null");
            }
        }
        private static void RequestedSeatNullCheck(int requestedSeatCount)
        {
            if (requestedSeatCount < 1)
            {
                throw new Exception("Requested seat count must be bigger than 0");
            }
        }

        private static void DirectionNullCheck(string from,string destination)
        {
            if (from.Length == 0 || destination.Length == 0)
            {
                throw new Exception("Direction Attributes cant be null");
            }
        }

    }
}

