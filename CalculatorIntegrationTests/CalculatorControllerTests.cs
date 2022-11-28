using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
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
        //var (application, client) = await CreateDbMock();

        var application = new CalculatorApiApplication();

        await PerformedOperationMockData.CreatePerformedOperations(application, true);

        var client = application.CreateClient();

        var url = "/operations";

        var result = await client.GetAsync(url);
        var performedOperations = await client.GetFromJsonAsync<List<PerformedOperation>>(url);

        result.StatusCode.Should().Be(HttpStatusCode.OK);
        performedOperations.Should().NotBeEmpty();
        performedOperations.Count.Should().Be(4);
    }

    [Fact]
    public async void GetAllOperations()
    {
        //Arrange
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();
        
        //Act
        var response = await client.GetAsync("/operations");
        var data = await response.Content.ReadAsStringAsync();

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        data.Should().NotBeEmpty();
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

