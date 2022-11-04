﻿using CsharpEvolution.Tests01.Persistence;
using CsharpEvolution.Tests01.SimpleCalculator;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using CsharpEvolution.Tests01.SimpleCalculator.Factory;
using CsharpEvolution.Tests01.SimpleCalculator.MathOperations;
using CsharpEvolution.Tests01.SimpleCalculator.MathOperations.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;

namespace CharpEvolution
{
    class Program
    {
        private readonly ISimpleCalculator _calculator;

        public Program(ISimpleCalculator calculator)
        {
            _calculator = calculator;
        }

        static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run();
        }

        private void Run()
        {

            _calculator.Calculate();

            Console.ReadKey();
            System.Environment.Exit(0);
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((services =>
                {
                    services.AddScoped<Program>();
                    services.AddScoped<ICalculatorRepository, CalculatorRepository>();
                    services.AddScoped<IDbContextCalculatorRepository, DbContextCalculatorRepository>();    
                    services.AddScoped<IOperationCache, OperationCache>();
                    services.AddScoped<ISimpleCalculator, SimpleCalculator>();
                    services.AddMemoryCache();
                    services.AddScoped<IMathOperationFactory, MathOperationFactory>();
                    services.AddScoped<AdditionOperation>();
                    services.AddScoped<SubtractionOperation>();
                    services.AddScoped<MultiplicationOperation>();
                    services.AddScoped<DivisionOperation>();
                    services.AddScoped<PerformedOperationContext>();
                    //services.AddDbContext<PerformedOperationContext>(op => op.UseSqlServer(Configuration.GetConnectionString("SqlServer")));

                    services.AddScoped<IReadOnlyDictionary<OperationType, IOperation>>((provider) =>
                    {
                        return new Dictionary<OperationType, IOperation>()
                {
                    { OperationType.SOMA, provider.GetService<AdditionOperation>() },
                    { OperationType.SUBTRAÇÃO, provider.GetService<SubtractionOperation>() },
                    { OperationType.MULTIPLICAÇÃO, provider.GetService<MultiplicationOperation>() },
                    { OperationType.DIVISÃO, provider.GetService<DivisionOperation>() },
                };
                    });

                    
                }));


        }
    }
}
