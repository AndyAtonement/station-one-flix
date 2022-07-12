using StationOneFlix.Models;

namespace StationOneFlix.Respositories
{
    public interface IFilmeRepository
    {
        Task<Filme> GetById(long id);
        Task<IEnumerable<Filme>> GetAll();
        Task<Filme> Create(Filme filme);
        Task<Filme> Update(Filme filme);
        Task<Filme> Delete(long id);
    }
}