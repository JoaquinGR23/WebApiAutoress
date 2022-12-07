using WebApiAutores;

var builder = WebApplication.CreateBuilder(args); //Crea un constructor

var startup = new Startup(builder.Configuration); //crea un objeto startup tipo Clase Startup

startup.ConfigureServices(builder.Services);

var app = builder.Build();

startup.Configure(app, app.Environment);

app.Run();
