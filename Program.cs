using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using proyectoef;

var builder = WebApplication.CreateBuilder(args);


// builder.Services.AddDbContext<TareasContext>(option => option.UseInMemoryDatabase("TareasDB"));
builder.Services.AddSqlServer<TareasContext>(builder.Configuration.GetConnectionString("cnTareas"));



var app = builder.Build();

app.MapGet("/", () => "Hello World!");


app.MapGet("/dbconexion", async ([FromServices] TareasContext dbContext) => 
{
    dbContext.Database.EnsureCreated();

    return Results.Ok("Base da Datos en Memoria : "+ dbContext.Database.IsInMemory());


});

app.Run();
