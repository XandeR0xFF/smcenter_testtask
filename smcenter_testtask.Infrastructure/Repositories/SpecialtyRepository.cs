using Microsoft.EntityFrameworkCore;
using smcenter_testtask.Domain.Aggregates.Specialties;
using smcenter_testtask.Domain.Primitives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace smcenter_testtask.Infrastructure.Repositories;

public class SpecialtyRepository(DatabaseContext context) : ISpecialtyRepository
{
    private readonly DatabaseContext _context = context;

    public IUnitOfWork UnitOfWork => _context;

    public async Task<IEnumerable<Specialty>> GetAllAsync()
    {
        return await _context.Specialties.ToArrayAsync();
    }

    public async Task<Specialty?> GetByIdAsync(long id)
    {
        return await _context.Specialties.FindAsync(id);
    }
}
