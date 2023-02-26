using Adesso.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Adesso.Controllers
{
    public class TravelController : Controller
    {
        // To add a user travel plan
        [HttpPost("/api/travels")]
        public async Task<IActionResult> AddTravel(Travel tavel)
        {
            // Add Travel 
            return null;
        }

        // To publish or unpublish a user travel plan
        [HttpPut("/api/travels/{id}")]
        public async Task<IActionResult> UupdateTravelStatus(int id, bool isPublished)
        {
            // Update Travel
            return null;
        }

        // To search for published travel plans of users in the system.
        [HttpGet("/api/travels")]
        public async Task<IActionResult> SearchTravels(string from, string to)
        {
            // Search Travels
            return null;
        }

        // To send a participation request to a published travel plan for users.
        [HttpPost("/api/travels/join")]
        public async Task<IActionResult> RequestToJoinTravel(int id, int seatCount)
        {
            // Katılım isteği gönderme işlemleri
            return null;
        }
    }
}
