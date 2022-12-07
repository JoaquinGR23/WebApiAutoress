using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApiAutores.Entidades;

namespace WebApiAutores.Controllers 
{ //La idea de esta configuracion es obtener las peticiones de los usuarios y retornar autores
    [ApiController]  // Es un atributo que permite hacer validaciones automaticas respecto a la data recibida de nuestro controlador
    [Route("api/autores")] // Se definen las rutas para los controladores, las peticiones paran aqui y el controlador va a trabajar con esa peticiones 
    public class AutoresController : ControllerBase //ControllerBase seguido de ctrl+. y Hereda propiedades de una claseBase==>microsoft.aspnetcore.mvc. Se ejecutara cuando se haga una peticion http hacia "api/autores"
    {
        private readonly ApplicationDbContext context;

        public AutoresController(ApplicationDbContext context) // constructor que recibe una instancia tipo ApplicationDbContext
        {
            this.context = context;
        }
        [HttpGet] //esta accion se activa cuando un usuario hace una peticion GET y retorna una lista de autores.
        public async Task<ActionResult<List<Autor>>> Get() // Este metodo se ejecuta con la accion HttpGet y retorna una lista de autores
        {   
            return await context.Autores.ToListAsync(); // Retorna un listado de  autores de la base de datos

        }

        [HttpPost] //esta accion se activa cuando un usuario hace una peticion POST.

        public async Task<ActionResult>Post(Autor autor)    
        {
            context.Add(autor); // Para crear un autor
            await context.SaveChangesAsync();   // Para guardar los cambios de manera asincrona
            return Ok();
        }
        [HttpPut("{id:int}")] //esta accion sirve para actualizar un determinado id api/autores/id

        public async Task<ActionResult> Put(Autor autor, int id)
        {
            if (autor.Id != id)
            {
                return BadRequest("La id del autor no coincide con la id de la URL");
            }
            var existe = await context.Autores.AnyAsync(x => x.Id == id); // Para saber si existe o no dicho autor 
            if (!existe)
            {
                return NotFound(); // Mensaje en caso de no existir
            }

            context.Update(autor); // Para actualizar un autor
            await context.SaveChangesAsync();   // Para guardar los cambios de manera asincrona
            return Ok();
        }

        [HttpDelete("{id:int}")] //esta accion sirve para BORRAR un determinado id api/autores/id

        public async Task<ActionResult> Delete(int id)
        {
            var existe = await context.Autores.AnyAsync(x=>x.Id == id); // Para saber si existe o no dicho autor 
            if (!existe)
            {
                return NotFound(); // Mensaje en caso de no existir
            }

            context.Remove(new Autor() { Id= id}) ; // Para remover un autor
            await context.SaveChangesAsync();   // Para guardar los cambios de manera asincrona
            return Ok();
        }
    }
}
