//using CsharpEvolution.Tests01.Persistence;
//using Microsoft.AspNetCore.Hosting;
//using Microsoft.AspNetCore.Mvc.Testing;
//using Microsoft.AspNetCore.TestHost;

//namespace CalculatorIntegrationTests;
//public class WebApplicationFactory 
//{
//    private readonly PerformedOperationContext _context;
//    private readonly HttpClient _client;

//    public WebApplicationFactory()
//    {
//        var builder = new WebHostBuilder()
//            //.UseEnvironment("Testing")
//            .UseStartup<Program>();

//        var server = new TestServer(builder);
//        _context = server.Host.Services.GetService(typeof(PerformedOperationContext)) as PerformedOperationContext;
//        _client = server.CreateClient();
//    }
    
//}

