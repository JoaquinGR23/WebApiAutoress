using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores
{
    public class ApplicationDbContext : DbContext
    {

        public ApplicationDbContext(DbContextOptions options) : base(options)                   //contructor para pasarle distintas confg. para EntityFramework
        {
        }
        public DbSet<Autor> Autores { get; set; }                                       //Propiedad que crea una tabla Autores en SQL server
                                                                                        //a partir de las propiedades de Autor
        public DbSet<Libro> Libros { get; set; }                                        // Para realizar queries o consultas directamente de libros 
    }
}
