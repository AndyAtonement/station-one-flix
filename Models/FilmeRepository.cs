using StationOneFlix.Data;
using StationOneFlix.Respositories;
using Microsoft.EntityFrameworkCore;

namespace StationOneFlix.Models
{
    public class FilmeRepository : IFilmeRepository
    {
        private readonly DataContext _context;

        public FilmeRepository(DataContext context)
        {
            _context = context;
        }

        public async Task<Filme> GetById(long id)
        {
            if(id == 0)
            {
                return null;
            }

            return await _context.Filmes.FindAsync(id);
        }

        public async Task<IEnumerable<Filme>> GetAll()
        {
            return await _context.Filmes.ToListAsync();
        }

        public async Task<Filme> Create(Filme filme)
        {
            if(filme.Id == 0)
            {
                _context.Filmes.Add(filme);
            }

            await _context.SaveChangesAsync();
            return filme;
        }

        public async Task Update(Filme filme)
        {
            _context.Entry(filme).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            var filmeParaDeletar = await _context.Filmes.FindAsync(id);
            _context.Filmes.Remove(filmeParaDeletar);
            await _context.SaveChangesAsync();
        }

    }
}