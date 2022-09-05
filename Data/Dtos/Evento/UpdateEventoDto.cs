using Exercicios.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exercicios.Data.Dtos.Evento
{
    public class UpdateEventoDto
    {
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
