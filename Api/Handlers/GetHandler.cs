using CsharpEvolution.Tests01.Persistence;
using CsharpEvolution.Tests01.SimpleCalculator.Entities;

namespace Api.Handlers;

public interface IGetHandler
{
    IEnumerable<PerformedOperation> Handle();
}

public class GetHandler : IGetHandler
{
    private readonly IUnitOfWorkDbContext _unitOfWorkDbContext;

    public GetHandler(IUnitOfWorkDbContext unitOfWorkDbContext)
    {
        _unitOfWorkDbContext = unitOfWorkDbContext;
    }

    public IEnumerable<PerformedOperation> Handle()
    {
        return _unitOfWorkDbContext.DbContextRepository.Find();
    }
}



