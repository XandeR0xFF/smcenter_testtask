using smcenter_testtask.Domain.Primitives;

namespace smcenter_testtask.Domain.Aggregates.Patients;

public interface IPatientRepository : IRepository
{
    void Add(Patient patient);
    void Delete(Patient patient);

    Task<Patient> GetByIdAsync(long id);
    Task<IEnumerable<Patient>> GetAllAsync(long page, long pageSize, string orderBy);
}
