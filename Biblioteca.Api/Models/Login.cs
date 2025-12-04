namespace Biblioteca.Api.Models
{
    public class Login
    {
        public int Id { get; set; }
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
        public string Username { get; set; } = string.Empty;
        public bool Inativo { get; set; }
        public DateTime DataCriacao { get; set; }
        public int UsuarioId { get; set; }

        public Usuario? Usuario { get; set; }
    }
}
