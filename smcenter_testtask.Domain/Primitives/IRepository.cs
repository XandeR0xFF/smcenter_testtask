namespace smcenter_testtask.Domain.Primitives;

public interface IRepository
{
    public IUnitOfWork UnitOfWork { get; }
}
