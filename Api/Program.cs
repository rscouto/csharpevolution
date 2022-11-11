using CsharpEvolution.Tests01.Persistence;

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

var app = builder.Build();

// Configure the HTTP request pipeline.

    app.UseSwagger();
    app.UseSwaggerUI();


app.UseHttpsRedirection();


app.MapGet("/operationsDbContext", (IUnitOfWorkDbContext _unitOfWorkDbContext) =>
{
    return _unitOfWorkDbContext.DbContextRepository.Find();
});

app.MapGet("/operations", (IUnitOfWork _unitOfWork) =>
{
   return _unitOfWork.CalculatorRepository.Find();
});

app.Run();

