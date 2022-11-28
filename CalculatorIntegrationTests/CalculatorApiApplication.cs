using CsharpEvolution.Tests01.Persistence;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace CalculatorIntegrationTests;
public class CalculatorApiApplication : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        var root = new InMemoryDatabaseRoot();

        builder.ConfigureServices(services =>
        {
            services.RemoveAll(typeof(DbContextOptions<PerformedOperationContext>));
            services.AddDbContext<PerformedOperationContext>(options =>

            options.UseInMemoryDatabase("Operations", root));
        });

        return base.CreateHost(builder);

    }
}
