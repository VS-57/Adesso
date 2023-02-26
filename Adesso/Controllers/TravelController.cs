using Adesso.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Adesso.Services;
using Adesso.Services.validation;

using System.Diagnostics;
using AutoMapper;

namespace Adesso.Controllers
{
    public class TravelController : Controller
    {
        private readonly ITravelService _travelService;

        private readonly IRequestValidator _requestValidator;

        public TravelController(ITravelService travelService,IMapper mapper,IRequestValidator requestValidator)
        {
            _travelService = travelService;
            _requestValidator = requestValidator;
        }
        // To add a user travel plan
        [HttpPost("/api/travels")]
        public async Task<IActionResult> AddTravel([FromBody] Travel travel)
        {
            await _requestValidator.ValidateAddTravel(travel);
            // Add Travel
            return new JsonResult(await _travelService.AddTravel(travel));
        }

        // To publish or unpublish a user travel plan
        [HttpPut("/api/travels/{id}")]
        public async Task<IActionResult> UupdateTravelStatus(int id, bool isPublished)
        {
            // Update Travel
             await _requestValidator.ValidateUpdateTravelStatus(id,isPublished);
            return new JsonResult(await _travelService.UpdateTravelStatus(id,isPublished));
        }

        // To search for published travel plans of users in the system.
        [HttpGet("/api/travels")]
        public async Task<IActionResult> SearchTravels(string from, string to)
        {
            // Search Travels
            await _requestValidator.ValidateSearchTravels(from,to);
            return new JsonResult(await _travelService.SearchTravels(from,to));
        }

        // To send a participation request to a published travel plan for users.
        [HttpPost("/api/travels/join")]
        public async Task<IActionResult> RequestToJoinTravel(int id, int seatCount)
        {
            await _requestValidator.ValidateRequestToJoinTravel(id,seatCount);
            return new JsonResult(await _travelService.RequestToJoinTravel(id, seatCount));
        }
    }
}
