using smcenter_testtask.Domain.Primitives;

namespace smcenter_testtask.Domain.Aggregates.Districts;

public interface IDistrictRepository : IRepository
{
    Task<District?> GetByIdAsync(long id);
    Task<IEnumerable<District>> GetAllAsync();
}
