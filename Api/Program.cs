using Api.Handlers;
using Api.Messages;
using CsharpEvolution.Tests01.Persistence;
using CsharpEvolution.Tests01.SimpleCalculator;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.Net;

var builder = WebApplication.CreateBuilder(args);


// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddScoped<PerformedOperationContext>();
builder.Services.AddScoped<ICalculatorRepository, CalculatorRepository>();
builder.Services.AddScoped<IDbContextCalculatorRepository, DbContextCalculatorRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IUnitOfWorkDbContext, UnitOfWorkDbContext>();
builder.Services.AddScoped<IValidator<MathOperationRequest>, MathOperationRequestValidator>();
builder.Services.AddScoped<ICalculatorHandler, CalculatorHandler>();

var app = builder.Build();

// Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();


app.UseHttpsRedirection();

app.MapGet("/calculation", (
    [FromBody] MathOperationRequest request,
    IValidator<MathOperationRequest> _mathOperationRequestValidator,
    ICalculatorHandler _calculator) =>
{
    if (_mathOperationRequestValidator.Validate(request) is { IsValid: false } validate)
        return new Response<MathOperationResponse>(HttpStatusCode.BadRequest, validate)
            .CreateActionResult();

    return _calculator.Handle(request);
});

app.MapGet("/operationsDbContext", (IUnitOfWorkDbContext _unitOfWorkDbContext) =>
{
    return _unitOfWorkDbContext.DbContextRepository.Find();
});

app.MapGet("/operations", (IUnitOfWork _unitOfWork) =>
{
    return _unitOfWork.CalculatorRepository.Find();
});

app.Run();

