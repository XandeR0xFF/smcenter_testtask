using smcenter_testtask.Domain.Primitives;

namespace smcenter_testtask.Domain.Aggregates.Specialties;

public interface ISpecialtyRepository : IRepository
{
    Task<Specialty?> GetByIdAsync(long id);
    Task<IEnumerable<Specialty>> GetAllAsync();
}
