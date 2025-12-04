using System.ComponentModel.DataAnnotations.Schema;

namespace Biblioteca.Api.Models
{
    public class Livro
    {
        public int Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Autor { get; set; } = string.Empty;

        [Column(TypeName = "varchar(15)")]
        public string ISBN { get; set; } = string.Empty;
        public int AnoPublicacao { get; set; }
        public int Paginas { get; set; }
        public string Sinopse { get; set; } = string.Empty;
        public DateTime DataCadastro { get; set; }

    }
}
