using smcenter_testtask.Domain.Primitives;

namespace smcenter_testtask.Domain.Aggregates.Doctors;

public interface IDoctorRepository : IRepository
{
    void Add(Doctor doctor);
    void Delete(Doctor doctor);

    Task<Doctor> GetByIdAsync(long id);
    Task<IEnumerable<Doctor>> GetAllAsync(long page, long pageSize, string orderBy);
}
