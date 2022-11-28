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
    public CalculatorControllerTests()
    {

    }

    [Fact]
    public async Task Given_a_get_request_should_return_ok_and_perfeormed_operations()
    {
        var (application, client) = await CreateDbMock();

        var url = "/operations";

        var result = await client.GetAsync(url);
        var performedOperations = await client.GetFromJsonAsync<List<PerformedOperation>>(url);

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        performedOperations.Should().NotBeEmpty();
        performedOperations.Count.Should().Be(4);
    }



    private static async Task<CalculatorApiApplication> CreateDbMock2()
    {
        var application = new CalculatorApiApplication();

        await PerformedOperationMockData.CreatePerformedOperations(application, true);

        var client = application.CreateClient();
        return application;
    }

    public async Task<(CalculatorApiApplication, HttpClient)> CreateDbMock()
    {
        var application = new CalculatorApiApplication();

        await PerformedOperationMockData.CreatePerformedOperations(application, true);

        var client = application.CreateClient();

        return (application, client);

    }
}

