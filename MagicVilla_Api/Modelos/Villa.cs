using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Api.Modelos
{
    public class Villa
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Detalle { get; set; }
        [Required]
        public double Tarifa { get; set; }

        public int Ocupantes { get; set; }

        public int Metroscuadrados { get; set; }

        public string ImagenUrl { get; set; }

        public string Amenidad { get; set; }

        public DateTime FechaCreacion { get; set; }

        public DateTime FechaActualizacio { get; set; }
    }
}
