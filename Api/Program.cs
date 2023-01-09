using Api.Handlers;
using Api.Messages;
using CsharpEvolution.Tests01.Domain.MathOperations.Enums;
using CsharpEvolution.Tests01.Infrastructure;
using CsharpEvolution.Tests01.Persistence;
using CsharpEvolution.Tests01.SimpleCalculator.Common;
using CsharpEvolution.Tests01.SimpleCalculator.Factory;
using CsharpEvolution.Tests01.SimpleCalculator.MathOperations;
using CsharpEvolution.Tests01.SimpleCalculator.MathOperations.Interfaces;
using FluentValidation;
using Microsoft.AspNetCore.Mvc.Testing;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();


builder.Services.AddScoped<PerformedOperationContext>();
builder.Services.AddScoped<IPerformedOperationRepository, PerformedOperationRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IValidator<MathOperationRequest>, MathOperationRequestValidator>();

builder.Services.AddScoped<ICalculateHandler, CalculateHandler>();
builder.Services.AddScoped<IGetHandler, GetHandler>();

builder.Services.AddScoped<IUtils, Utils>();

builder.Services.AddScoped<WebApplicationFactory<Program>>();

builder.Services.AddMemoryCache();
builder.Services.AddScoped<IOperationCache, OperationCache>();

builder.Services.AddScoped<IMathOperationFactory, MathOperationFactory>();

builder.Services.AddScoped<AdditionOperation>();
builder.Services.AddScoped<SubtractionOperation>();
builder.Services.AddScoped<MultiplicationOperation>();
builder.Services.AddScoped<DivisionOperation>();

builder.Services.AddScoped<IReadOnlyDictionary<MathOperation, IOperation>>((provider) =>
{
    return new Dictionary<MathOperation, IOperation>()
                {
                    { MathOperation.Addition, provider.GetService<AdditionOperation>() },
                    { MathOperation.Subtraction, provider.GetService<SubtractionOperation>() },
                    { MathOperation.Multiplication, provider.GetService<MultiplicationOperation>() },
                    { MathOperation.Division, provider.GetService<DivisionOperation>() },
                };
});

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapPost("/operations", (
    MathOperationRequest request,
    ICalculateHandler _calculator) =>
{
    return _calculator.Handle(request);
});

app.MapGet("/operations", (IGetHandler _get) =>
{
    return _get.Handle();
});

app.Run();

public partial class Program { }