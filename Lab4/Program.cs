using System.Reflection;
using Application.Commands.Aircrafts;
using Application.Commands.FlightDestinations;
using Application.Handlers.Aircrafts;
using Application.Mappers;
using Application.Validation.Aircraft;
using AutoMapper;
using Domain.Interfaces;
using Domain.Interfaces.Repositories;
using FluentValidation;
using FluentValidation.AspNetCore;
using Infrastructure;
using Infrastructure.Data;
using Infrastructure.Data.Repositories;
using Lab4;
using Lab4.Consumers;
using Lab4.Middlewares;
using MassTransit;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddSwaggerGen();

//
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssembly(typeof(GetAircraftsHandler).GetTypeInfo().Assembly);
});

builder.Services.AddMassTransit(x =>
{
    x.AddConsumer<AircraftCreatedConsumer>();
    x.UsingRabbitMq((context, cfg) =>
    {
        cfg.ConfigureEndpoints(context);
    });
});

builder.Services.AddValidatorsFromAssemblyContaining<CreateAircraftCommandValidator>();
builder.Services.AddValidatorsFromAssemblyContaining<DeleteAircraftCommand>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateAircraftCommandValidator>();

builder.Services.AddValidatorsFromAssemblyContaining<CreateFlightDestinationCommand>();
builder.Services.AddValidatorsFromAssemblyContaining<DeleteFlightDestinationCommand>();
builder.Services.AddValidatorsFromAssemblyContaining<UpdateFlightDestinationCommand>();

builder.Services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();


string connectionString = 
    builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AirportDatabaseContext>(
    options => options.UseMySql(
        connectionString,
        ServerVersion.AutoDetect(connectionString)
    )
);


var mapperConfig = new MapperConfiguration(mc =>
{
    mc.AddProfile(new MapperConfig());
});
IMapper mapper = mapperConfig.CreateMapper();
builder.Services.AddSingleton(mapper);


builder.Services.AddScoped<IAircraftRepository, AircraftRepository>();
builder.Services.AddScoped<IFlightDestinationRepository, FlightDestinationRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();

builder.Services.AddControllers();


var app = builder.Build();


app.MapGet("/", () => "Hello World!");


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<ExceptionHandlerMiddleware>();

app.MapControllers();

app.Run();