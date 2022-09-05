using Exercicios.Models;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Exercicios.Data.Dtos.Evento
{
    public class CreateEventoDto
    {
        public string Descricao { get; set; }

        public decimal CapacidadePublico { get; set; }

        public DateTime Data { get; set; }

        [Required]
        [ForeignKey("Banda")]
        public int BandaId { get; set; }

        public BandaModel? Banda { get; set; }
    }
}
