using MagicVilla_Api.Modelos.Dto;

namespace MagicVilla_Api.Datos
{
    public class VillaStore
    {
        public static List<VillaDto> villalist = new List<VillaDto>
        {
           new VillaDto{Id=1,Nombre="vista a la piscina "  , Ocupante=3 , Metroscuadrados=50 },
           new VillaDto{Id=2,Nombre="vista a la playa " ,Ocupante=4 , Metroscuadrados=80  },


        };
        
    }
}
