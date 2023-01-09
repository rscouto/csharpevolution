﻿using Api.Handlers;
using AutoFixture;
using CsharpEvolution.Tests01.Persistence;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using FluentAssertions;
using Moq;
using System.Net;
using Xunit;

namespace Calculator.UnitTests;
public class GetHandlerTestsB
{

    private readonly Fixture _fixture;
    private readonly Mock<IUnitOfWorkDbContext> _repositoryMock;
    private readonly GetHandler _handler;

    public GetHandlerTestsB()
    {
        _fixture = new Fixture();
        _repositoryMock = new Mock<IUnitOfWorkDbContext>(MockBehavior.Strict);
        _handler = new GetHandler(_repositoryMock.Object);
    }

    [Fact]
    public void Given_no_operations_in_DB_should_return_empty_list()
    {
        //Arrange

        _repositoryMock.Setup(x => x.DbContextRepository.Find())
            .Returns((Enumerable.Empty<PerformedOperation>));

        //Act
        var result = _handler.Handle();

        //Assert
        _repositoryMock.Verify(x => x.DbContextRepository.Find(),
            Times.Once);
        result.Should().BeEmpty();
    }

    [Fact]
    public void Given_populated_DB_should_return_list_of_operations()
    {
        //Arrange

        var operations = _fixture.Build<PerformedOperation>()
           .Without(x => x.Id)
           .CreateMany();

        _repositoryMock.Setup(x => x.DbContextRepository.Find())
            .Returns(operations);

        //Act
        var result = _handler.Handle();

        //Assert
        _repositoryMock.Verify(x => x.DbContextRepository.Find(),
            Times.Once);
        result.Should().BeEquivalentTo(operations);
    }


}
