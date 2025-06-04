
using ReconhecimentoFacialApp.Data;
using Microsoft.EntityFrameworkCore;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using ReconhecimentoFacialApp.Repositories;
using ReconhecimentoFacialApp.Repositorios;
using ReconhecimentoFacialApp.Service;
using ReconhecimentoFacialApp.Service.Interface; 

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

// Injeção de Repositórios
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<IValidacaoRepository, ValidacaoRepository>();

// Injeção de Serviços
builder.Services.AddScoped<IUsuariosService, UsuarioService>();
builder.Services.AddScoped<IValidacaoService, ValidacaoService>();
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection"))); 

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
