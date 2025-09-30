using Q10.TaskManager.Infrastructure.Interfaces;
using Q10.TaskManager.Infrastructure.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

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
builder.Services.AddScoped<IConfig, SettingsRepository>();
builder.Services.AddScoped<IConfig, EnvironmentRepository>();
builder.Services.AddControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}

app.UseHttpsRedirection();

// Formas de acceder a una variable de entorno
//var en1 = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
//var en2 = app.Configuration["ASPNETCORE_ENVIRONMENT"];

// Como se usa controladores se tienen que mapear estos.
app.MapControllers();

app.Run();