using CsharpEvolution.Tests01.Persistence;
using CsharpEvolution.Tests01.SimpleCalculator;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using System;


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
                    services.AddScoped<IOperationCache, OperationCache>();
                    services.AddScoped<ISimpleCalculator, SimpleCalculator>();
                    services.AddMemoryCache();

                    services.AddSingleton<ICalculatorRepositorySettings>(sp =>
            sp.GetRequiredService<IOptions<CalculatorRepositorySettings>>().Value);
                }));
        }
    }
}
