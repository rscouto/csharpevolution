using CharpEvolution;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CsharpEvolution.Tests01.SimpleCalculator
{
    public class CalculatorExtensions
    {
        private static IHostBuilder CreateHostBuilder(string[] args)
        {
            return Host.CreateDefaultBuilder(args)
                .ConfigureServices((Action<IServiceCollection>)(services =>
                {
                    services.AddScoped<Program>();
                    services.AddScoped<IOperationCache, OperationCache>();
                }));
        }
    }
}
