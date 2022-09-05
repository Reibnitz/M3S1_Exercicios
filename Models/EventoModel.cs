using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Exercicios.Models
{
    [Table("Evento")]
    public class EventoModel
    {
        [Key]
        public int Id { get; set; }

        public string Descricao { get; set; }

        public decimal CapacidadePublico { get; set; }

        public DateTime Data { get; set; }

        public int TipoEvento { get; set; }

        [Required]
        [ForeignKey("Banda")]
        public int BandaId { get; set; }

        public BandaModel? Banda { get; set; }
    }
}
