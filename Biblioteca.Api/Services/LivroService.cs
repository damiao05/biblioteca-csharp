using Biblioteca.Api.Models;
using Biblioteca.Api.Data;
using Microsoft.EntityFrameworkCore;

namespace Biblioteca.Api.Services
{
    public class LivroService : ILivroService
    {
        private readonly ApplicationDbContext _context;

        public LivroService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Livro>> GetAllLivrosAsync()
        {
            return await _context.Livros.ToListAsync();
        }

        public async Task<Livro> CreateLivroAsync(Livro livro)
        {
            _context.Livros.Add(livro);
            await _context.SaveChangesAsync();
            return livro;
        }

        public async Task<Livro?> GetLivroByAsync(int id)
        {
            return await _context.Livros.FindAsync(id);
        }

        public async Task<bool> DeleteLivroAsync(int id)
        {
            var livro = await _context.Livros.FindAsync(id);
            if (livro == null) return false;

            _context.Livros.Remove(livro);
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> UpdateLivroAsync(Livro livro)
        {
            _context.Entry(livro).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
                return true;
            }
            catch (DbUpdateConcurrencyException)
            {
                if (_context.Livros.Any(e => e.Id == livro.Id) == false) 
                {
                    return false;
                }
                throw;
            }
        }
    }
}
