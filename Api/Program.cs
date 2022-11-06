using CsharpEvolution.Tests01.Persistence;
using CsharpEvolution.Tests01.SimpleCalculator.Factory;
using CsharpEvolution.Tests01.SimpleCalculator.MathOperations.Interfaces;
using CsharpEvolution.Tests01.SimpleCalculator.MathOperations;
using CsharpEvolution.Tests01.SimpleCalculator;
using Microsoft.EntityFrameworkCore;
using MongoDB.Driver.Core.Configuration;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<ISimpleCalculator, SimpleCalculator>();
builder.Services.AddMemoryCache();
builder.Services.AddScoped<IOperationCache, OperationCache>();
builder.Services.AddScoped<IMathOperationFactory, MathOperationFactory>();
builder.Services.AddScoped<AdditionOperation>();
builder.Services.AddScoped<SubtractionOperation>();
builder.Services.AddScoped<MultiplicationOperation>();
builder.Services.AddScoped<DivisionOperation>();
builder.Services.AddScoped<PerformedOperationContext>();
builder.Services.AddScoped<ICalculatorRepository, CalculatorRepository>();
builder.Services.AddScoped<IDbContextCalculatorRepository, DbContextCalculatorRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IReadOnlyDictionary<OperationType, IOperation>>((provider) =>
{
    return new Dictionary<OperationType, IOperation>()
                {
                    { OperationType.SOMA, provider.GetService<AdditionOperation>() },
                    { OperationType.SUBTRAÇÃO, provider.GetService<SubtractionOperation>() },
                    { OperationType.MULTIPLICAÇÃO, provider.GetService<MultiplicationOperation>() },
                    { OperationType.DIVISÃO, provider.GetService<DivisionOperation>() },
                };
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();


app.MapGet("/operationsDbContext", async (IUnitOfWork _unitOfWork) =>
{
    return _unitOfWork.DbContextRepository.Find();
});

app.MapGet("/operations", async (IUnitOfWork _unitOfWork) =>
{
   return _unitOfWork.DbContextRepository.Find();
});

app.Run();

