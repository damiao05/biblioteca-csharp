using Biblioteca.Api.DTOs;
using Biblioteca.Api.Models;

namespace Biblioteca.Api.Services.Interfaces
{
    public interface IUsuarioService
    {
        Task<Usuario?> GetUsuarioByIdAsync(int id);
        Task<Usuario> CadastrarNovoUsuario(UsuarioCadastroDto dto);
    }
}
