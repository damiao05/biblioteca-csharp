using Biblioteca.Api.Models;
using Biblioteca.Api.Data;
using Microsoft.EntityFrameworkCore;
using Biblioteca.Api.DTOs;
using Biblioteca.Api.Services.Interfaces;

namespace Biblioteca.Api.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly ApplicationDbContext _context;

        public UsuarioService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario?> GetUsuarioByIdAsync(int id)
        {
            return await _context.Usuarios.FindAsync(id);
        }

        public async Task<Usuario> CadastrarNovoUsuario(UsuarioCadastroDto dto)
        {
            var novoEndereco = new Endereco
            {
                CEP = dto.Cep,
                Rua = dto.Rua,
                Cidade = dto.Cidade,
                Estado = dto.Estado
            };
            _context.Enderecos.Add(novoEndereco);
            await _context.SaveChangesAsync();

            var novoUsuario = new Usuario
            {
                Nome = dto.Nome,
                CPF = dto.CPF,
                DataNascimento = dto.DataNascimento,
                DataCadastro = DateTime.UtcNow,
                EnderecoId = novoEndereco.Id
            };
            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync();

            var senhaHash = dto.Senha; // Implementar hash de senha real

            var novoLogin = new Login
            {
                Email = dto.Email,
                Username = dto.Username,
                Senha = senhaHash,
                Inativo = false,
                DataCriacao = DateTime.UtcNow,
                UsuarioId = novoUsuario.Id
            };
            _context.Logins.Add(novoLogin);
            await _context.SaveChangesAsync();

            return novoUsuario;
        }

    }
}
