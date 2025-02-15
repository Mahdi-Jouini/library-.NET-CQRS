using System.Reflection;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;
using Data.Context;
using Domain.Handler;
using Domain.Interface;
using GestionUtilisateur.Data.Repository;
using API.Mapper;
using Domain.Models;
using Domain.Queries;
using Domain.Commands;
using MediatR; // Make sure you have the correct namespace for IRepository

var builder = WebApplication.CreateBuilder(args);

// Add DbContext to the container
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"),
    sqlOptions => sqlOptions.MigrationsAssembly("API")));

// Register the repository implementation (open generic registration)
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

// Add MediatR scanning for both assemblies
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()); // API assembly
    cfg.RegisterServicesFromAssembly(typeof(GetAllGenericHandler<>).Assembly);
    cfg.RegisterServicesFromAssembly(typeof(PostGenericHandler<>).Assembly);// Domain assembly
});

// If you explicitly registered the handler for Livre (closed version), you can do:
builder.Services.AddTransient<
    MediatR.IRequestHandler<GetAllGeneric<Livre>, IEnumerable<Domain.Models.Livre>>,
    GetAllGenericHandler<Livre>>();

builder.Services.AddTransient<IRequestHandler<PostGeneric<Livre>, string>, PostGenericHandler<Livre>>();



// Add AutoMapper
builder.Services.AddAutoMapper(typeof(MapperProfiles));

// Add controllers and Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();
