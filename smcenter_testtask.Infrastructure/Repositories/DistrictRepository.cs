using Microsoft.EntityFrameworkCore;
using smcenter_testtask.Domain.Aggregates.Districts;
using smcenter_testtask.Domain.Primitives;

namespace smcenter_testtask.Infrastructure.Repositories;

public class DistrictRepository(DatabaseContext context) : IDistrictRepository
{
    private readonly DatabaseContext _context = context;

    public IUnitOfWork UnitOfWork => _context;

    public async Task<IEnumerable<District>> GetAllAsync()
    {
        return await _context.Districts.ToArrayAsync();
    }

    public async Task<District?> GetByIdAsync(long id)
    {
        return await _context.Districts.FindAsync(id);
    }
}
