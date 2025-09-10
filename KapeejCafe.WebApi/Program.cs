using KapeejCafe.Application.Common.Interfaces;
using KapeejCafe.Infrastructure.Persistence;
using KapeejCafe.Infrastructure.Repositories;
using KapeejCafe.Infrastructure.UnitOfWork;
using MediatR;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;
using KapeejCafe.Application.Ingredientes.Commands;
using KapeejCafe.Application.Products.Commands;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<KapeejCafeDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IUnitiOfWork, UnitOfWork>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(
    typeof(CrearIngredienteHandler).Assembly
));

builder.Services.AddControllers();
builder.Services.AddValidatorsFromAssemblyContaining<CrearIngredienteHandler>();
builder.Services.AddValidatorsFromAssemblyContaining<CrearProductoHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

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
