using Adesso.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Adesso.Services;
using System.Diagnostics;
using AutoMapper;

namespace Adesso.Controllers
{
    public class TravelController : Controller
    {
        private readonly ITravelService _travelService;

        public TravelController(ITravelService travelService,IMapper mapper)
        {
            _travelService = travelService;
        }
        // To add a user travel plan
        [HttpPost("/api/travels")]
        public async Task<IActionResult> AddTravel([FromBody] Travel travel)
        {
            // Add Travel
            return new JsonResult(await _travelService.AddTravel(travel));
        }

        // To publish or unpublish a user travel plan
        [HttpPut("/api/travels/{id}")]
        public async Task<IActionResult> UupdateTravelStatus(int id, bool isPublished)
        {
            // Update Travel
            return new JsonResult(await _travelService.UpdateTravelStatus(id,isPublished));
        }

        // To search for published travel plans of users in the system.
        [HttpGet("/api/travels")]
        public async Task<IActionResult> SearchTravels(string from, string to)
        {
            // Search Travels
            return new JsonResult(await _travelService.SearchTravels(from,to));
        }

        // To send a participation request to a published travel plan for users.
        [HttpPost("/api/travels/join")]
        public async Task<IActionResult> RequestToJoinTravel(int id, int seatCount)
        {
            // Katılım isteği gönderme işlemleri
            await _travelService.RequestToJoinTravel(id, seatCount);
            return new JsonResult(true);
        }
    }
}
