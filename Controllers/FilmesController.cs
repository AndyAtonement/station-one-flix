using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StationOneFlix.Data;
using StationOneFlix.Models;
using StationOneFlix.Respositories;

namespace StationOneFlix.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeRepository _filmeRepository;
        private DataContext _context;

        public FilmesController(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        [Route("listagem-de-filmes")]
        [HttpGet("{id}")]
        public async Task<IActionResult> ListarFilmeById(long id)
        {
            var filme = await _filmeRepository.GetById(id);
            return Ok(filme);
        }

        [HttpGet]
        public async Task<IActionResult> ListarFilmes()
        {
            var filmes = await _filmeRepository.GetAll();
            return Ok(filmes);
        }

        [Route("cadastro-de-filmes")]
        [HttpPost]
        public async Task<IActionResult> CadastrarFilme([FromBody] Filme filme)
        {
            var filmeCriado = await _filmeRepository.Create(filme);
            return CreatedAtAction(nameof(_filmeRepository.GetAll), new { id = filmeCriado.Id }, filmeCriado);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> EditarFilme([FromBody] Filme filme)
        {
            _context.Entry(filme).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return Ok(filme);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletarFilme(long id)
        {
            var filmeDeletado = await _filmeRepository.GetById(id);
            return Ok(filmeDeletado);
        }
    }
}

