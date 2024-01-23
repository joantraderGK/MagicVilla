using System.ComponentModel.DataAnnotations;

namespace MagicVilla_Api.Modelos.Dto
{
    public class VillaDto
    {

        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Nombre { get; set; }

        public string Detalle { get;  set; }
        [Required]
        public double Tarifa { get; set; }
        public int Ocupante { get; set; }

        public int Metroscuadrados { get; set; }

        public string ImagenUrl { get;  set; }

        public string Amenidad { get; set; }

    }
}
