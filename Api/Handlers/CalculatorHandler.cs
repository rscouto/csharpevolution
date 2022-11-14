using Api.Messages;
using CsharpEvolution.Tests01.Persistence;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using CsharpEvolution.Tests01.SimpleCalculator.Factory;
using CsharpEvolution.Tests01.SimpleCalculator;
using System.Text;

namespace Api.Handlers;

public interface ICalculatorHandler
{
    decimal Handle(MathOperationRequest request);
}

public class CalculatorHandler : ICalculatorHandler
{
    private readonly IMathOperationFactory _operationFactory;
    private readonly ISimpleCalculator _simpleCalculator;
    private readonly IOperationCache _cache;
    //private readonly IUnitOfWork _unitOfWork;
    private readonly IUnitOfWorkDbContext _unitOfWorkDbContext;
    private readonly List<string> _mathOperations = new List<string> { "SOMA", "SUBTRAÇÃO",
                                                                    "MULTIPLICAÇÃO", "DIVISÃO" };

    public CalculatorHandler(
        IOperationCache cache,
        //IUnitOfWork unitOfWork,
        IUnitOfWorkDbContext unitOfWorkDbContext,
        ISimpleCalculator simpleCalculator, 
        IMathOperationFactory operationFactory)
    {
        _cache = cache;
        //_unitOfWork = unitOfWork;
        _unitOfWorkDbContext = unitOfWorkDbContext;
        _simpleCalculator = simpleCalculator;
        _operationFactory = operationFactory;
    }

    public decimal Handle(MathOperationRequest request)
    {
        var result = _operationFactory.Calculate(request.MathOperation, request.NumOne, request.NumTwo);

        var performedOperation = new PerformedOperation(request.MathOperation, request.NumOne, request.NumTwo, result);

        var persistedId = _unitOfWorkDbContext.DbContextRepository.Create(performedOperation);
        //var persistedId = _unitOfWork.CalculatorRepository.Create(performedOperation);

        performedOperation.Id = persistedId;

        _unitOfWorkDbContext.DbContextRepository.Find();
        //_unitOfWork.CalculatorRepository.Find();

        _simpleCalculator.StoreInCache(performedOperation);

        return result;
    }
}


    
