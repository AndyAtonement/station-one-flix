using Microsoft.EntityFrameworkCore;
using StationOneFlix.Models;

namespace StationOneFlix.Data
{
    public class DataContext : DbContext
    {
        public DbSet<Filme> Filmes { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }
        
    }
}
