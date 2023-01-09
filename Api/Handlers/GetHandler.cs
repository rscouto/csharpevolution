using CsharpEvolution.Tests01.Persistence;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;

namespace Api.Handlers;

public interface IGetHandler
{
    IEnumerable<PerformedOperation> Handle();
}

public class GetHandler : IGetHandler
{
    private readonly IUnitOfWork _unitOfWork;

    public GetHandler(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    public IEnumerable<PerformedOperation> Handle()
    {
        return _unitOfWork.PerformedOperationRepository.Find();
    }
}



