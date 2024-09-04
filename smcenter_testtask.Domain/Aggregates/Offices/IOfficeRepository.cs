using smcenter_testtask.Domain.Primitives;

namespace smcenter_testtask.Domain.Aggregates.Offices;

public interface IOfficeRepository : IRepository
{
    Task<Office> GetByIdAsync(long id);
    Task<IEnumerable<Office>> GetAllAsync();
}
