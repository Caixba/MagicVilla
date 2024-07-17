using MagicVilla_API.Modelos;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Datos
{
    //Aqui se agregan los modelos que se crean como una tabla en la bd
    public class ApplicationDbContext : DbContext
    {
        //Contructor. sE manda tod la configuracion de la cadena de conexion por medio de inyeccin de dependecias del selvicio
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) :base (options)
        {
            
        }

        public DbSet<Villa> Villas { get; set; }

        //Alimentando una vez tabla villa con un add-migration alimentar tablaVilla
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Se agrega la configuracion de la tabla
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Nombre = "Villa 1",
                    Detalle = "Villa de lujo",
                    ImagenUrl = "",
                    Ocupantes = 4,
                    MetrosCuadrados = 200,
                    Tarifa = 1000,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now
                },
                new Villa()
                {
                    Id = 2,
                    Nombre = "Villa 2",
                    Detalle = "Villa de lujo2",
                    ImagenUrl = "",
                    Ocupantes = 5,
                    MetrosCuadrados = 300,
                    Tarifa = 2000,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now
                },
                new Villa()
                {
                    Id = 3,
                    Nombre = "Villa 3",
                    Detalle = "Villa de luj3o",
                    ImagenUrl = "",
                    Ocupantes = 6,
                    MetrosCuadrados = 400,
                    Tarifa = 3000,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now
                }

            );
        }

    }
}
