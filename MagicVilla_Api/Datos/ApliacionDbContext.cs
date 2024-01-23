using MagicVilla_Api.Modelos;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_Api.Datos
{
    public class ApliacionDbContext:DbContext
    {
        public ApliacionDbContext(DbContextOptions<ApliacionDbContext> options) : base (options)
        {
          
        }

        public DbSet<Villa> villa {  get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().HasData(
                new Villa()
                {
                    Id = 1,
                    Nombre = "Villa Real",
                    Detalle = "Detalle de la Villa...",
                    ImagenUrl = "",
                    Ocupantes = 5,
                    Metroscuadrados = 50,
                    Tarifa = 200,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacio = DateTime.Now,

                },
                   new Villa()
                   {
                        Id = 2,
                        Nombre = "Primium vitas  a la Piscina",
                        Detalle = "Detalle de la Villa...",
                        ImagenUrl = "",
                        Ocupantes = 4,
                        Metroscuadrados = 40,
                        Tarifa = 150,
                        Amenidad = "",
                        FechaCreacion = DateTime.Now,
                        FechaActualizacio = DateTime.Now,

                   }
              );
        }
    }
}
