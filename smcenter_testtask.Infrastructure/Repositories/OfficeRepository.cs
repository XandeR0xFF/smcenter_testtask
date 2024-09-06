using Microsoft.EntityFrameworkCore;
using smcenter_testtask.Domain.Aggregates.Offices;
using smcenter_testtask.Domain.Primitives;

namespace smcenter_testtask.Infrastructure.Repositories;

public class OfficeRepository(DatabaseContext context) : IOfficeRepository
{
    private readonly DatabaseContext _context = context;

    public IUnitOfWork UnitOfWork => _context;

    public async Task<IEnumerable<Office>> GetAllAsync()
    {
        return await _context.Offices.ToArrayAsync();
    }

    public async Task<Office?> GetByIdAsync(long id)
    {
        return await _context.Offices.FindAsync(id);
    }
}
