using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;
using TareFacil.Application.Services;
using TareFacil.Domain.Entities;
using TareFacil.Domain.Interfaces.Repositories;
using TareFacil.Infra.Data.Contexts;
using TareFacil.Infra.Data.Repositories;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();

builder.Services.AddDbContext<DataContext>(options =>
    options.UseMySql(
        builder.Configuration.GetConnectionString("BDTareFacil"),
        ServerVersion.AutoDetect(builder.Configuration.GetConnectionString("BDTareFacil"))
    )
);

builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<IBaseRepository<Tarefa>, TarefaRepository>();
builder.Services.AddScoped<TarefaService>();

var allowedOrigins = builder.Configuration
    .GetSection("Cors:AllowedOrigins")
    .Get<string[]>();

builder.Services.AddCors(options => {
    options.AddPolicy("AngularApp", policy => {
        policy.WithOrigins(allowedOrigins!)
        .AllowAnyHeader()
        .AllowAnyMethod();
    });
});

var app = builder.Build();


if (app.Environment.IsDevelopment()) {
    app.MapOpenApi();
}

app.UseSwagger();
app.UseSwaggerUI();

app.MapScalarApiReference(s => s.WithTheme(ScalarTheme.DeepSpace));

app.UseCors("AngularApp");

app.UseAuthorization();

app.MapControllers();

app.Run();
