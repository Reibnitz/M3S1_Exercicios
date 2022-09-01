using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercicios.Models
{
    [Table("Banda")]
    public class BandaModel
    {
        [Key]
        public int Id { get; set; }

        public string Descricao { get; set; }

        public int GeneroMusical { get; set; }

        public bool Solo { get; set; }
    }
}
