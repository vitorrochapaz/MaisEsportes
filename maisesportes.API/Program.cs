using maisesportes.API.Endpoints;
using maisesportes.Shared.Dados;
using maisesportes.Shared.Modelos;
using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<maisEsportesContext>();
builder.Services.AddTransient<DAL<Aluno>>();
builder.Services.AddTransient<DAL<Professor>>();
builder.Services.AddTransient<DAL<Turma>>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.MapAlunosEndpoints();
app.AddEndpointProfessores();
app.MapTurmasEndpoints();

app.UseSwagger();
app.UseSwaggerUI();

app.Run();
