using Api.Messages;
using AutoFixture;
using CsharpEvolution.Tests01.Domain.MathOperations.Enums;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Globalization;
using System.Net;
using System.Net.Http.Json;
using System.Text;

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

    [InlineData(MathOperation.Addition, 200, -500, -300)]
    [InlineData(MathOperation.Subtraction, -200, -500, -700)]
    [InlineData(MathOperation.Multiplication, 20, 60, 1200)]
    [InlineData(MathOperation.Division, 30, 120, 0.25)]
    [Theory]
    public async Task Given_request_should_return_correct_result(MathOperation mathOperation, decimal numberOne, decimal numberTwo, decimal result)
    {
        //Arrange

        await using var application = new WebApplicationFactory<Program>();
        using var client = application.CreateClient();

        var request = _fixture.Build<MathOperationRequest>()
            .With(x => x.operation, mathOperation)
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
}

