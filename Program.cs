using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using minimalapi.Dominio.Entidades;
using minimalapi.Dominio.Interfaces;
using minimalapi.Dominio.Servico;
using minimalapi.DTOs;
using minimalapi.infraestrutura.Db;


var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

builder.Services.AddScoped<IAdministradorServico, AdministradorServico>();

builder.Services.AddDbContext<DbContexto>(
    options =>
    {
        options.UseMySql(
            builder.Configuration.GetConnectionString("mysql"),
            ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("mysql"))
        );
    }
);

app.MapGet("/", () => "Hello World!");

app.MapPost("/login", ([FromBody] LoginDTO loginDTO, IAdministradorServico administradorServico) => {
    if (administradorServico.Login(loginDTO) != null)
        return Results.Ok("Login com sucesso");
    else
        return Results.Unauthorized();      
});

app.Run();

