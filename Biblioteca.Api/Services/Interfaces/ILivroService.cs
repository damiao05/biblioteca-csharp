using Biblioteca.Api.Models;

namespace Biblioteca.Api.Services.Interfaces
{
    public interface ILivroService
    {
        Task<IEnumerable<Livro>> GetAllLivrosAsync();
        Task<Livro?> GetLivroByAsync(int id);
        Task<Livro> CreateLivroAsync(Livro livro);
        Task<bool> UpdateLivroAsync(Livro livro);
        Task<bool> DeleteLivroAsync(int id);
    }
}
