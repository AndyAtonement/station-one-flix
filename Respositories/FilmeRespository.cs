using StationOneFlix.Data;
using StationOneFlix.Models;

namespace StationOneFlix.Respositories
{
    public class FilmeRespository : IFilmeRepository
    {
        private readonly Context _context;

        public FilmeRespository(Context context)
        {
            _context = context;
        }

        public async Task<Filme> GetById(long id)
        {
            return await _context.Filmes.FindAsync(id);
        }

        public async Task<IEnumerable<Filme>> GetAll()
        {
            return await _context.Filmes.ToListAsync();
        }

        public async Task<Filme> Create(Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();
            return filme;
        }

        public async Task<Filme> Update(Filme filme)
        {
            _context.Filmes.Update(filme);
            await _context.SaveChangesAsync();
            return filme;
        }

        public async Task<Filme> Delete(long id)
        {
            var filme = await _context.Filmes.FindAsync(id);
            if (filme == null)
            {
                return null;
            }

            _context.Filmes.Remove(filme);
            await _context.SaveChangesAsync();
            return filme;
        }
    }
}