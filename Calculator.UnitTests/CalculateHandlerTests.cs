using Api.Handlers;
using Api.Messages;
using AutoFixture;
using CsharpEvolution.Tests01.Persistence;
using CsharpEvolution.Tests01.SimpleCalculator.Common;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using CsharpEvolution.Tests01.SimpleCalculator.Factory;
using FluentAssertions;
using Moq;
using Xunit;

namespace Calculator.UnitTests;
public class CalculateHandlerTests
{

    private readonly Fixture _fixture;
    private readonly Mock<IUnitOfWorkDbContext> _repositoryMock;
    private readonly Mock<IUtils> _utilsMock;
    private readonly Mock<IMathOperationFactory> _factoryMock;
    private readonly CalculateHandler _handler;

    public CalculateHandlerTests()
    {
        _fixture = new Fixture();
        _repositoryMock = new Mock<IUnitOfWorkDbContext>(MockBehavior.Strict);
        _utilsMock = new Mock<IUtils>(MockBehavior.Strict);
        _factoryMock = new Mock<IMathOperationFactory>(MockBehavior.Strict);
        _handler = new CalculateHandler(_repositoryMock.Object, _utilsMock.Object, _factoryMock.Object);
    }

    [Fact]
    public void Given_request_should_return_correct_result()
    {
        //Arrange

        var request = _fixture.Build<MathOperationRequest>()
            .With(x => x.MathOperation == "soma")
            .With(x => x.NumOne == 366)
            .With(x => x.NumTwo == 244)
            .Create();  

        var operation = _fixture.Build<PerformedOperation>()
            .With(x => x.MathOperation == "soma")
            .With(x => x.NumOne == 366)
            .With(x => x.NumTwo == 244)
            .Create();


        _factoryMock.Setup(x => x.Calculate(operation.MathOperation, operation.NumOne, operation.NumTwo))
            .Returns(operation.Result);

        //Act
        var result = _handler.Handle(request);

        //Assert
        _repositoryMock.Verify(x => x.DbContextRepository.Create(operation),
            Times.Once);
        result.Should().Equals(operation.Result);
    }

}
