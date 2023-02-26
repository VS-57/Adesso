using Adesso.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Adesso.Data
{
    public class MyDbContext : DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }

        public DbSet<Travel> Travels { get; set; }
    }
}
