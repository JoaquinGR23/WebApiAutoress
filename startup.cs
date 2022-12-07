using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace WebApiAutores
{
    public class Startup
    {
        public Startup(IConfiguration configuration)  // CONSTRUCTOR
        {
            Configuration = configuration;
        }
        public IConfiguration Configuration { get; } //Propiedad

        public void ConfigureServices(IServiceCollection services) //PARA Conf. de los servicios
        {
            services.AddControllers();        
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            services.AddDbContext<ApplicationDbContext>(Options =>
                Options.UseSqlServer(Configuration.GetConnectionString("defaultConnection"))); //Para conectar la base de datos a la WebApi

        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env) //env es el ambiente 
        {
            if (env.IsDevelopment())                                            //para conf. los middlewares.
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
  

    
}
