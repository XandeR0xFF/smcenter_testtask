using Microsoft.EntityFrameworkCore;
using smcenter_testtask.Domain.Aggregates.Doctors;
using smcenter_testtask.Domain.Primitives;
using System.Linq.Expressions;
using System.Numerics;

namespace smcenter_testtask.Infrastructure.Repositories;

public class DoctorRepository(DatabaseContext context) : IDoctorRepository
{
    private readonly DatabaseContext _context = context;


    public IUnitOfWork UnitOfWork => _context;

    public void Add(Doctor doctor)
    {
        _context.Doctors.Add(doctor);
    }

    public void Delete(Doctor doctor)
    {
        _context.Entry(doctor).State = EntityState.Deleted;
    }

    public async Task<IEnumerable<Doctor>> GetAllAsync(int page, int pageSize, string? orderBy)
    {
        IQueryable<Doctor> query = _context.Doctors;
        query = query.Include(d => d.Office).Include(d => d.Specialty).Include(d => d.District);

        Expression<Func<Doctor, object>> keySelector = doctor => doctor.Id;
        if (!String.IsNullOrEmpty(orderBy))
        {
            keySelector = orderBy.ToLower() switch
            {
                "name" => doctor => doctor.FullName,
                "office" => doctor => doctor.Office.Number,
                "specialty" => doctor => doctor.Specialty.Title,
                "district" => doctor => doctor.District.Number,
                _ => doctor => doctor.Id
            };
        }
        query = query.OrderBy(keySelector);

        return await query.Skip((page - 1) * pageSize).Take(pageSize).ToArrayAsync();
    }

    public async Task<Doctor?> GetByIdAsync(long id)
    {
        Doctor? doctor = await _context.Doctors.Include(d => d.Office).Include(d => d.Specialty).Include(d => d.District).FirstOrDefaultAsync(d => d.Id == id);
        return doctor;
    }
}
