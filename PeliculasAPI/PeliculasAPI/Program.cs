using Microsoft.AspNetCore.Builder;
using PeliculasAPI;

var builder = WebApplication.CreateBuilder(args);

var startup = new Startup(builder.Configuration);

startup.ConfigureServices(builder.Services);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c =>
    {
        c.SwaggerEndpoint("/swagger/v1/swagger.json", "API V1");
        c.RoutePrefix = string.Empty; // Esto hará que la UI de Swagger esté en la ruta raíz (localhost:5000/)
    });
}

startup.Configure(app, app.Environment);

app.Run();