namespace WebApiAutores.Entidades
{
    public class Libro  // la clase libro y autores estan relacionadas
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public int AutorId { get; set; }    //llave foranea
        public Autor Autor { get; set; }  // Propiedad de navegacion y para relacionar un libro con un autor
    }
}
