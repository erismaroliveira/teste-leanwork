using LeanWork.Atividade3.Infra.Contexts;
using LeanWork.Atividade3.Infra.Repositories.Interfaces;
using LeanWork.Atividade3.Infra.Repositories;
using Microsoft.EntityFrameworkCore;
using LeanWork.Atividade3.Domain.Entities;
using LeanWork.Atividade3.Application.Services.Interfaces;
using LeanWork.Atividade3.Application.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddDbContext<LeanWorkContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IGenericRepository<Tecnologia>, GenericRepository<Tecnologia>>();
builder.Services.AddScoped<IGenericRepository<Candidato>, GenericRepository<Candidato>>();
builder.Services.AddScoped<IGenericRepository<Vaga>, GenericRepository<Vaga>>();
builder.Services.AddScoped<IGenericRepository<PesoTecnologiaVaga>, GenericRepository<PesoTecnologiaVaga>>();

builder.Services.AddScoped<ISistemaRecrutamentoService, SistemaRecrutamentoService>();
builder.Services.AddScoped<ITecnologiaService, TecnologiaService>();
builder.Services.AddScoped<IVagaService, VagaService>();
builder.Services.AddScoped<ICandidatoService, CandidatoService>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
