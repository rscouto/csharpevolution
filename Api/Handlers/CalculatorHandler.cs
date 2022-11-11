using Api.Messages;
using CsharpEvolution.Tests01.Persistence;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;
using CsharpEvolution.Tests01.SimpleCalculator.Factory;
using CsharpEvolution.Tests01.SimpleCalculator;
using System.Text;

namespace Api.Handlers;

public interface ICalculatorHandler
{
    void Handle(MathOperationRequest request);
}

public class CalculatorHandler : ICalculatorHandler
{
    private readonly string _quit = "Q";
    private readonly IMathOperationFactory _operationFactory;
    private readonly IOperationCache _cache;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUnitOfWorkDbContext _unitOfWorkDbContext;
    private readonly List<string> _mathOperations = new List<string> { "SOMA", "SUBTRAÇÃO",
                                                                    "MULTIPLICAÇÃO", "DIVISÃO" };

    public CalculatorHandler(
        IOperationCache cache,
        IUnitOfWork unitOfWork,
        IUnitOfWorkDbContext unitOfWorkDbContext,
        IMathOperationFactory operationFactory)
    {
        _cache = cache;
        _unitOfWork = unitOfWork;
        _unitOfWorkDbContext = unitOfWorkDbContext;
        _operationFactory = operationFactory;
    }

    public void Handle(MathOperationRequest request)
    {
        var result = _operationFactory.Calculate(request.MathOperation.ToString(), request.NumOne, request.NumTwo);

        var performedOperation = new PerformedOperation(request.MathOperation.ToString(), request.NumOne, request.NumTwo, result);

        _unitOfWorkDbContext.DbContextRepository.Create(performedOperation);
        var persistedId = _unitOfWork.CalculatorRepository.Create(performedOperation);

        performedOperation.Id = persistedId;

        _unitOfWorkDbContext.DbContextRepository.Find();
        _unitOfWork.CalculatorRepository.Find();

        StoreInCache(performedOperation);

        Console.WriteLine($"O resultado da sua operação é: {result}");
        Console.WriteLine("Deseja efetuar mais alguma operação? S/N");
        var input = Console.ReadLine();

        Console.Clear();

        if (input.Equals("s", StringComparison.CurrentCultureIgnoreCase)) { Calculate(); }
        EscapeApplication();
    }
}


    
