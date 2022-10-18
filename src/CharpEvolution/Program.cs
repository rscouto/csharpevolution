using CsharpEvolution.Tests01.SimpleCalculator;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Data.SqlClient;

namespace CharpEvolution
{
    class Program
    {
        private readonly IMemoryCache _cache;

        public Program(IMemoryCache cache)
        {
            _cache = cache;
        }
    
        static void Main(string[] args)
        {
            IHost host = CreateHostBuilder(args).Build();
            host.Services.GetRequiredService<Program>().Run();
        }

        private void Run()
        {
            SimpleCalculator calculator = new SimpleCalculator(_cache);
            calculator.Calculate();

            Console.ReadKey();
            System.Environment.Exit(0);
        }

        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices(services =>
                {
                    services.AddScoped<Program>();
                    services.AddScoped<IOperationCache, OperationCache>();

                    services.AddMemoryCache();
                });
        }
    }
}
