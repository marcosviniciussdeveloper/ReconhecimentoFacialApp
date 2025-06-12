
using ReconhecimentoFacialApp.Data;
using Microsoft.EntityFrameworkCore;
using ReconhecimentoFacialApp.Repositories;
using ReconhecimentoFacialApp.Repositorios;
using ReconhecimentoFacialApp.Service;
using ReconhecimentoFacialApp.Service.Interface; 

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddCors( options =>
{
    options.AddPolicy("AllownAngularApp", policy =>
    {
        policy.WithOrigins("http://localhost:4200") // URL do Angular
               .AllowAnyMethod()
               .AllowAnyHeader();




    });


});



// Add services to the container.

// Injeção de Repositórios
builder.Services.AddScoped<IUsuariosRepository, UsuariosRepository>();
builder.Services.AddScoped<IValidacaoRepository, ValidacaoRepository>();
builder.Services.AddScoped<INotificacaoRepository, NotificacaoRepository>();

// Injeção de Serviços
builder.Services.AddScoped<IUsuariosService, UsuarioService>();
builder.Services.AddScoped<IValidacaoService, ValidacaoService>();
builder.Services.AddScoped<INotificacaoService, NotificacaoService>();
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
app.UseCors("AllownAngularApp");
app.UseAuthorization();

app.MapControllers();

app.Run();
