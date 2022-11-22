using Microsoft.AspNetCore.Mvc.Testing;

namespace CalculatorIntegrationTests;
public class WebApplicationFactory 
{
    private readonly HttpClient _client;

	public WebApplicationFactory()
	{
		var appFactory = new WebApplicationFactory<Program>();
		_client = appFactory.CreateClient(); 
	}

	[Fact]	
	public void Test()
	{
		var response = _client.GetAsync(_client.BaseAddress).GetAwaiter().GetResult();
	} 
}

