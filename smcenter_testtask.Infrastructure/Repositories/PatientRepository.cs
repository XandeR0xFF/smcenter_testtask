using Microsoft.EntityFrameworkCore;
using smcenter_testtask.Domain.Aggregates.Patients;
using smcenter_testtask.Domain.Primitives;
using System.Linq.Expressions;

namespace smcenter_testtask.Infrastructure.Repositories;

public class PatientRepository(DatabaseContext context) : IPatientRepository
{
    private readonly DatabaseContext _context = context;

    public IUnitOfWork UnitOfWork => _context;

    public void Add(Patient patient)
    {
        _context.Patients.Add(patient);
    }

    public void Delete(Patient patient)
    {
        _context.Entry(patient).State = EntityState.Deleted;
    }

    public async Task<IEnumerable<Patient>> GetAllAsync(int page, int pageSize, string? orderBy)
    {
        IQueryable<Patient> query = _context.Patients;
        query = query.Include(p => p.District);

        Expression<Func<Patient, object>> keySelector = patient => patient.Id;
        if (!String.IsNullOrEmpty(orderBy))
        {
            keySelector = orderBy.ToLower() switch
            {
                "fname" => patient => patient.FirstName,
                "lname" => patient => patient.LastName,
                "pname" => patient => patient.PatronymicName,
                "address" => patient => patient.Address,
                "sex" => patient => patient.Sex,
                "district" => patient => patient.District.Number,
                _ => patient => patient.Id
            };
        }
        query = query.OrderBy(keySelector);

        return await query.Skip((page - 1) * pageSize).Take(pageSize).ToArrayAsync();
    }

    public async Task<Patient?> GetByIdAsync(long id)
    {
        return await _context.Patients.Include(p => p.District).FirstOrDefaultAsync(p => p.Id == id);
    }
}
