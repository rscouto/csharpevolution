using Api.Messages;
using AutoFixture;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.AspNetCore.Routing;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.Http.Json;
using System.Reflection.Metadata;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace CalculatorIntegrationTests;
public class CalculatorControllerTests 
{
    private readonly Fixture _fixture;

    public CalculatorControllerTests()
    {
        _fixture = new Fixture();
    }

    [Fact]
    public async Task Given_a_get_request_should_return_ok()
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

    [Fact]
    public async Task Given_a_get_request_should_return_perfeormed_operations()
    {
        //Arrange 
        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        //Act
        var response = await client.GetAsync("/operations");
        var data = await response.Content.ReadFromJsonAsync<IEnumerable<PerformedOperation>>();

        //Assert
        response.StatusCode.Should().Be(HttpStatusCode.OK);
        data.Should().HaveCountGreaterThan(1);
    }

    [InlineData("soma", 200, -500, -300)]
    [InlineData("subtração", -200, -500, -700)]
    [InlineData("multiplicação", 20, 60, 1200)]
    [InlineData("divisão", 30, 120, 0.25)]
    [Theory]
    public async Task Given_request_should_return_correct_result(string mathOperation, decimal numberOne, decimal numberTwo, decimal result)
    {
        //Arrange

        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        var request = _fixture.Build<MathOperationRequest>()
            .With(x => x.MathOperation, mathOperation)
            .With(x => x.NumOne, numberOne)
            .With(x => x.NumTwo, numberTwo)
            .Create();

        //Act
        var orderJson = JsonConvert.SerializeObject(request);

        var contentRequest = new StringContent(orderJson, Encoding.UTF8, "application/json");

        var response = await client.PostAsync("/operations", contentRequest);

        var persistedResult = decimal.Parse(await response.Content.ReadAsStringAsync(), CultureInfo.InvariantCulture);


        //Assert

        persistedResult.Should().Be(result);
        response.StatusCode.Should().Be(HttpStatusCode.OK);
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

