//using CsharpEvolution.Tests01.Persistence;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.Extensions.Configuration;
//using Microsoft.Extensions.DependencyInjection;

//namespace CalculatorIntegrationTests;
//public class WebApplicationFixture
//{
//    private const string _appsettingsTest = "appsettings.Test.json";

//    private static readonly HttpClient _client;
//    private static readonly IServiceProvider _serviceProvider;


//    public HttpClient Client { get; }
//    public IServiceProvider ServiceProvider { get; }

//    static WebApplicationFixture()
//    {
//        (_client, _serviceProvider) = CreateHttpClient();
//    }

//    public WebApplicationFixture()
//    {
//        (Client, ServiceProvider) = (_client, _serviceProvider);
//    }

//    private static (HttpClient, IServiceProvider) CreateHttpClient()
//    {
//        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");

//        var configuration = new ConfigurationFixture();

//        var application = new WebApplicationFactory<Program>()
//            .WithWebHostBuilder(x =>
//            {
//                x.UseContentRoot(Environment.CurrentDirectory);
//                x.UseConfiguration(configuration.Configuration);
//            });


//        //var scopeFactory = application.Server.Host.Services.GetService<IServiceScopeFactory>();
//        //using (var scope = scopeFactory.CreateScope())
//        //{
//        //var _context = scope.ServiceProvider.GetService<PerformedOperationContext>();
//        //}

//        //application.Server.Host.Services.GetService<IServiceScopeFactory>();
//        //using (var scope = application.Server.Host.Services.GetService<IServiceScopeFactory>().CreateScope())
//        //{

//        //application.Server.Host.Services.GetService<IServiceScopeFactory>();
//        //application.Server.Host.Services.GetService<PerformedOperationContext>();
        
//        //}

//        application.Services.CreateScope().ServiceProvider.GetService<PerformedOperationContext>();

//        return (application.Server.CreateClient(), application.Services);
//    }

//    [Fact]
//    public void Test()
//    {
//        var httpGetResult = _client.GetAsync($"\"/operations\"");

//    }
//}

//public class ConfigurationFixture
//{
//    public IConfiguration Configuration { get; private set; }

//    public ConfigurationFixture()
//    {
//        Configuration = new ConfigurationBuilder()
//            .SetBasePath(Environment.CurrentDirectory)
//            .AddEnvironmentVariables()
//            .Build();
//    }
//}


