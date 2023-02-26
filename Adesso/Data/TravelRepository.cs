using Adesso.Data.IRepositories;
using Adesso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Adesso.Data
{
    public class TravelRepository : ITravelRepository
    {
        private readonly MyDbContext _context;

        public TravelRepository(MyDbContext context)
        {
            _context = context;
        }

        public async Task<Travel> AddTravel(Travel newTravel)
        {
            await _context.Travels.AddAsync(newTravel);
            await _context.SaveChangesAsync();

            return newTravel;
        }

        public async Task UpdateTravel(Travel travel)
        {
            _context.Travels.Update(travel);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Travel>> SearchTravels(string from, string to)
        {
            var travels = await _context.Travels
                .Where(t => t.From == from && t.Destination == to && t.isPublished == true)
                .ToListAsync();

            return travels;
        }

        public async Task<Travel> GetTravelById(int travelId)
        {
            var travel = await _context.Travels.FindAsync(travelId);

            return travel;
        }
    }

}
