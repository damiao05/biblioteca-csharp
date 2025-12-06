using Biblioteca.Api.Models;
using Biblioteca.Api.DTOs;
using Microsoft.AspNetCore.Mvc;
using Biblioteca.Api.Services.Interfaces;

namespace Biblioteca.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuariosController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuariosController(IUsuarioService service)
        {
            _usuarioService = service;
        }

        [HttpGet]
        public async Task<ActionResult<Usuario>> GetUsuarioById(int id)
        {
            var usuario = await _usuarioService.GetUsuarioByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return Ok(usuario);
        }

        [HttpPost]
        public async Task<ActionResult> Post([FromBody] UsuarioCadastroDto dto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            try
            {
                var novoUsuario = await _usuarioService.CadastrarNovoUsuario(dto);
                return CreatedAtAction(nameof(GetUsuarioById), new { id = novoUsuario.Id }, novoUsuario);
            }
            catch (Exception ex)
            {
                return StatusCode(500, "Erro interno ao cadastrar usuário: " + ex.Message);
            }
        }
    }
}
