using StationOneFlix.Models;

namespace StationOneFlix.Respositories
{
    public interface IFilmeRepository
    {
        Task<Filme> GetById(long id);
        Task<IEnumerable<Filme>> GetAll();
        Task<Filme> Create(Filme filme);
        Task Update(Filme filme);
        Task Delete(long id);
    }
}