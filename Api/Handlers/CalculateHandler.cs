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
    private readonly IUnitOfWork _unitOfWork;

    public CalculateHandler(
        IUnitOfWork unitOfWork,
        IUtils utils, 
        IMathOperationFactory operationFactory)
    {
        _unitOfWork = unitOfWork;
        _utils = utils;
        _operationFactory = operationFactory;
    }

    public decimal Handle(MathOperationRequest request)
    {
        using var _ = this.MeasureTimeCurrentMethod();  

        var result = _operationFactory.Calculate(request.operation, request.NumOne, request.NumTwo);

        var performedOperation = new PerformedOperation(request.operation, request.NumOne, request.NumTwo, result);

        var persistedId = _unitOfWork.PerformedOperationRepository.Create(performedOperation);

        performedOperation.Id = persistedId;

        _utils.StoreInCache(performedOperation);

        _unitOfWork.Commit();

        return result;
    }
}


    
