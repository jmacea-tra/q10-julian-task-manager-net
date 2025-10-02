using Microsoft.OpenApi.Models;
using Q10.TaskManager.Api.Configurations;
using Q10.TaskManager.Infrastructure.Interfaces;
using Q10.TaskManager.Infrastructure.Repositories;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "API de Gestión de Tareas Q10",
        Description = "API para la gestión de tareas y configuraciones del sistema",
        Version = "v1",
        Contact = new OpenApiContact
        {
            Name = "Equipo de Desarrollo",
            Email = "desarrollo@q10.com"
        }
    });

    // Configuración para incluir los comentarios XML
    var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
    var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
    options.IncludeXmlComments(xmlPath);
});

builder.Services.AddServices();

// Registro de IMemoryCache y CacheRepository como singleton
builder.Services.AddMemoryCache();

// Forma normal de usar la biblioteca de clases.
//var settignsRepository = new SettingsRepository(builder.Configuration);
//var enviromentRepository = new EnvironmentRepository(builder.Configuration);

//Configuración de contenedor de dependencias
// Ventajas: no genera mas instantes es una hasta que el sistema muera.
// * Todos tiene acceso a esa instancia.
// Desventajas: Si se usa para valores cambiantes nunca se cambiaria.

// La forma más común es el Scoped o Transient
// Ventaja: Se genera por usuario o sea si ingresa Brayan y crea una instancia solo Brayan tiene acceso a esa instancia en memoria.

// Ventaja: Se genera una instancia por cada petición http.
// * Solo para logica de negocio.
//builder.Services.AddScoped<IConfig, EnvironmentRepository>();

builder.Services.AddControllers();

var app = builder.Build();

// Habilitar Swagger en todos los ambientes
app.UseSwagger();
app.UseSwaggerUI(c =>
{
    c.SwaggerEndpoint("/swagger/v1/swagger.json", "API de Gestión de Tareas Q10 v1");
    c.RoutePrefix = "swagger"; // Para que Swagger UI sea la página de inicio
});
app.UseHttpsRedirection();

// Formas de acceder a una variable de entorno
//var en1 = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
//var en2 = app.Configuration["ASPNETCORE_ENVIRONMENT"];

// Como se usa controladores se tienen que mapear estos.
app.MapControllers();

app.Run();