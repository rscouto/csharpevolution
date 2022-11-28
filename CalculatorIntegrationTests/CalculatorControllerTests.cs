using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Routing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace CalculatorIntegrationTests;
public class CalculatorControllerTests
{
    private HttpClient _client;

    public CalculatorControllerTests()
    {
        _client = CreateClient();
    }


    [Fact]
    public async Task Given_a_get_request_should_return_ok_and_perfeormed_operations()
    {
        

        var url = "/operations";

        var result = await _client.GetAsync(url);
        var performedOperations = await _client.GetFromJsonAsync<List<PerformedOperation>>("/performedOperations");

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        performedOperations.Should().NotBeEmpty();
        performedOperations.Count.Should().Be(4);
    }



    public  HttpClient CreateClient()
    {
        var application = new CalculatorApiApplication();

        PerformedOperationMockData.CreatePerformedOperations(application, true);

        var client = application.CreateClient();

        return client;

    }
}

