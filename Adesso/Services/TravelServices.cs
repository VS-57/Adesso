using Adesso.Data.IRepositories;
using Adesso.Models;
using Adesso.DTOs;
using AutoMapper;
using System.Diagnostics;
using System.Net;

namespace Adesso.Services
{
    public class TravelService : ITravelService

    {
        private readonly ITravelRepository _travelRepository;
        private readonly IMapper _mapper;

        public TravelService(ITravelRepository travelRepository,IMapper mapper)
        {
            _travelRepository = travelRepository;
            _mapper = mapper;
        }

        public async Task<ResponseDto<TravelDto>> AddTravel(Travel newTravel)
        {
            if (newTravel == null)
            {
                throw new ArgumentNullException(nameof(newTravel));
            }

            newTravel.isPublished = false; // Travels are not published by default

            await _travelRepository.Create(newTravel);

            return ResponseDto<TravelDto>.Create(_mapper.Map<TravelDto>(newTravel));
        }

        public async Task<ResponseDto<TravelDto>> UpdateTravelStatus(int travelId, bool isPublished)
        {
            var travel = await _travelRepository.GetById(travelId);

            if (travel == null)
            {
                throw new Exception("The specified travel could not be found");
            }

            travel.isPublished = isPublished;

             _travelRepository.Update(travel);

            return ResponseDto<TravelDto>.Succes((int)HttpStatusCode.OK,_mapper.Map<TravelDto>(travel));
        }

        public async Task<List<TravelDto>> SearchTravels(string from, string to)
        {
            var travel = await _travelRepository.SearchTravels(from, to);

            return _mapper.Map<List<TravelDto>>(travel);
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

            _travelRepository.Update(travel);
        }
    }
}
