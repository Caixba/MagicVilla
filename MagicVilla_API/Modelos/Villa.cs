using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

//No olvidar configurar la configuracion de la conexion en appsettings.json
namespace MagicVilla_API.Modelos
{
    public class Villa
    {
        //PK,ir aumentando 1 en 1 y automaticamente
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Detalle { get; set; }
        [Required]
        public double Tarifa { get; set; }
        public int Ocupantes { get; set; }
        public int MetrosCuadrados { get; set; }
        public string ImagenUrl { get; set; }
        public string Amenidad { get; set; }
        public DateTime FechaCreacion { get; set; }
        public DateTime FechaActualizacion { get; set; }
    }
}
