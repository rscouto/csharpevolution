using Api.Messages;
using CsharpEvolution.Tests01.Persistence;
using CsharpEvolution.Tests01.SimpleCalculator.Common;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using CsharpEvolution.Tests01.SimpleCalculator.Factory;

namespace Api.Handlers;

public interface ICalculateHandler
{
    decimal Handle(MathOperationRequest request);
}

public class CalculateHandler : ICalculateHandler
{
    private readonly IMathOperationFactory _operationFactory;
    private readonly IUtils _utils;
    private readonly IUnitOfWorkDbContext _unitOfWorkDbContext;

    public CalculateHandler(
        IUnitOfWorkDbContext unitOfWorkDbContext,
        IUtils utils, 
        IMathOperationFactory operationFactory)
    {
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

        _utils.StoreInCache(performedOperation);

        _unitOfWorkDbContext.Commit();

        return result;
    }
}


    
