using Adesso.Data.IRepositories;
using Adesso.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Adesso.Data
{
    public class TravelRepository : GenericRepository<Travel>,ITravelRepository
    {
        private readonly MyDbContext _context;

        public TravelRepository(MyDbContext context) : base(context)
        {
            
        }


        public async Task<List<Travel>> SearchTravels(string from, string to)
        {
            var travels = await GetAll()
                .Where(t => t.From == from && t.Destination == to && t.isPublished == true)
                .ToListAsync();

            return travels;
        }

    }

}
