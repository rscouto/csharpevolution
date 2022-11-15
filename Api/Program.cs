using Api.Handlers;
using Api.Messages;
using CsharpEvolution.Tests01.Persistence;
using CsharpEvolution.Tests01.SimpleCalculator;
using CsharpEvolution.Tests01.SimpleCalculator.Common;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using CsharpEvolution.Tests01.SimpleCalculator.Factory;
using CsharpEvolution.Tests01.SimpleCalculator.MathOperations;
using CsharpEvolution.Tests01.SimpleCalculator.MathOperations.Interfaces;
using FluentValidation;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PerformedOperationContext>();
builder.Services.AddScoped<IDbContextCalculatorRepository, DbContextCalculatorRepository>();
builder.Services.AddScoped<IUnitOfWorkDbContext, UnitOfWorkDbContext>();
builder.Services.AddScoped<IValidator<MathOperationRequest>, MathOperationRequestValidator>();

builder.Services.AddScoped<ICalculateHandler, CalculateHandler>();
builder.Services.AddScoped<IGetHandler, GetHandler>();    

builder.Services.AddScoped<IUtils, Utils>();

builder.Services.AddMemoryCache();
builder.Services.AddScoped<IOperationCache, OperationCache>();

builder.Services.AddScoped<IMathOperationFactory, MathOperationFactory>();

builder.Services.AddScoped<AdditionOperation>();
builder.Services.AddScoped<SubtractionOperation>();
builder.Services.AddScoped<MultiplicationOperation>();
builder.Services.AddScoped<DivisionOperation>();

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

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapPost("/operations", (
    MathOperationRequest request,
    IValidator<MathOperationRequest> _mathOperationRequestValidator,
    ICalculateHandler _calculator) =>
{
    return _calculator.Handle(request);
});

app.MapGet("/operations", (IGetHandler _get) =>
{
    return _get.Handle();
});

app.Run();

