using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Api.Data;
using Biblioteca.Api.Models;
using Biblioteca.Api.Services.Interfaces;

namespace Biblioteca.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LivrosController : ControllerBase
    {
        private readonly ILivroService _service;
        
        public LivrosController(ILivroService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Livro>>> GetLivros()
        {
            return Ok(await _service.GetAllLivrosAsync());
        }

        [HttpPost]
        public async Task<ActionResult<Livro>> PostLivro(Livro livro)
        {
            var createdLivro = await _service.CreateLivroAsync(livro);

            return CreatedAtAction(nameof(GetLivros), new { id = createdLivro.Id }, createdLivro);
        }
    }
}
