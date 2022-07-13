using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using StationOneFlix.Data;
using StationOneFlix.Models;
using StationOneFlix.Respositories;

namespace StationOneFlix.Controllers
{
    [Route("api/v1/filmes")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly IFilmeRepository _filmeRepository;

        public FilmesController(IFilmeRepository filmeRepository)
        {
            _filmeRepository = filmeRepository;
        }

        [Route("listagem-de-filmes/{id}")]
        [HttpGet]
        public async Task<IActionResult> ListarFilmeById(long id)
        {
            var filme = await _filmeRepository.GetById(id);
            return Ok(filme);
        }

        [HttpGet]
        public async Task<IEnumerable<Filme>> ListarFilmes()
        {
            return await _filmeRepository.GetAll();
        }

        [Route("cadastro-de-filmes")]
        [HttpPost]
        public async Task<IActionResult> CadastrarFilme([FromBody] Filme filme)
        {
            if(filme.Id == 0)
            {
                var novoFilme = await _filmeRepository.Create(filme);
                return CreatedAtAction(nameof(ListarFilmes), new { id = novoFilme.Id }, novoFilme);
            }

            return BadRequest();
        }

        [HttpPut]
        public async Task<IActionResult> EditarFilme([FromBody] Filme filme, long id)
        {
            if(id != filme.Id)
            {
                return BadRequest();
            }

            await _filmeRepository.Update(filme);

            return NoContent();
        }

        [HttpDelete]
        public async Task<IActionResult> DeletarFilme(long id)
        {
            var filmeDeletado = await _filmeRepository.GetById(id);
            if (filmeDeletado != null)
            {
                return NotFound();
            }

            await _filmeRepository.Delete(filmeDeletado.Id);

            return NoContent();
        }
    }
}

