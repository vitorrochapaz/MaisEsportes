using maisesportes.API.Endpoints;
using maisesportes.Shared.Dados;
using maisesportes.Shared.Modelos;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<maisEsportesContext>();
builder.Services.AddTransient<DAL<Aluno>>();
builder.Services.AddTransient<DAL<Professor>>();
builder.Services.AddTransient<DAL<Turma>>();

// 🔹 Adiciona configuração de CORS
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBlazor", policy =>
    {
        policy.WithOrigins("https://localhost:7226") // endereço do Blazor
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// 🔹 Ativa CORS (antes dos endpoints)
app.UseCors("AllowBlazor");

app.MapAlunosEndpoints();
app.AddEndpointProfessores();
app.MapTurmasEndpoints();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
