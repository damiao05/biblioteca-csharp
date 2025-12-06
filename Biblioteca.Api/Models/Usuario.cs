using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Api.Models
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        [Column(TypeName = "varchar(11)")]
        public string CPF { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public int EnderecoId { get; set; }

        public Endereco? Endereco { get; set; }

        public ICollection<Login> HistoricoLogins { get; set; } = new List<Login>();
    }
}
