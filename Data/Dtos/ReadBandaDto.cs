using System.ComponentModel.DataAnnotations;

namespace Exercicios.Data.Dtos
{
    public class ReadBandaDto
    {
        [Key]
        public int Id { get; set; }

        public string Descricao { get; set; }

        public int GeneroMusical { get; set; }

        public bool Solo { get; set; }
    }
}
