using Microsoft.EntityFrameworkCore;
using StationOneFlix.Models;

namespace StationOneFlix.Data
{
    public class Context : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }

        public Context(DbContextOptions<Context> options) : base(options)
        {
            Database.EnsureCreated();
        }
        
    }
}