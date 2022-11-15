using Api.Messages;
using CsharpEvolution.Tests01.Persistence;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using CsharpEvolution.Tests01.SimpleCalculator.Factory;
using CsharpEvolution.Tests01.SimpleCalculator;
using System.Text;
using CsharpEvolution.Tests01.SimpleCalculator.Common;

namespace Api.Handlers;

public interface ICalculatorHandler
{
    decimal Handle(MathOperationRequest request);
}

public class CalculatorHandler : ICalculatorHandler
{
    private readonly IMathOperationFactory _operationFactory;
    private readonly IUtils _utils;
    private readonly IOperationCache _cache;
    private readonly IUnitOfWorkDbContext _unitOfWorkDbContext;

    public CalculatorHandler(
        IOperationCache cache,
        IUnitOfWorkDbContext unitOfWorkDbContext,
        IUtils utils, 
        IMathOperationFactory operationFactory)
    {
        _cache = cache;
        _unitOfWorkDbContext = unitOfWorkDbContext;
        _utils = utils;
        _operationFactory = operationFactory;
    }

    public decimal Handle(MathOperationRequest request)
    {
        var result = _operationFactory.Calculate(request.MathOperation, request.NumOne, request.NumTwo);

        var performedOperation = new PerformedOperation(request.MathOperation, request.NumOne, request.NumTwo, result);

        var persistedId = _unitOfWorkDbContext.DbContextRepository.Create(performedOperation);

        performedOperation.Id = persistedId;

        _unitOfWorkDbContext.DbContextRepository.Find();

        _utils.StoreInCache(performedOperation);

        return result;
    }
}


    
