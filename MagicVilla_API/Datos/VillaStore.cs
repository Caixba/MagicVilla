using MagicVilla_API.Modelos.DTO;

namespace MagicVilla_API.Datos
{
    public static class VillaStore
    {
        //Lsita
        public static List<VillaDto> villalist = new List<VillaDto>
        {
            new VillaDto { Id = 1, Nombre = "Vista a la piscina" , Ocupantes = 3, MetrosCuadrados = 50 },
            new VillaDto { Id = 2, Nombre = "Vista a la ciudad", Ocupantes = 5, MetrosCuadrados = 100 },
            new VillaDto { Id = 3, Nombre = "Vista a la playa", Ocupantes = 4, MetrosCuadrados = 70}
        };


    }
}
