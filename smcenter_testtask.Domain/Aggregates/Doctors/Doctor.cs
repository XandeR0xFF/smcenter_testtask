using smcenter_testtask.Domain.Aggregates.Districts;
using smcenter_testtask.Domain.Aggregates.Offices;
using smcenter_testtask.Domain.Aggregates.Specialties;
using smcenter_testtask.Domain.Primitives;

namespace smcenter_testtask.Domain.Aggregates.Doctors;

public class Doctor : Entity
{
    private Doctor()
    {
    }

    public Doctor(string fullName, Office office, Specialty specialty, District district)
    {
        FullName = String.Empty;
        FullName = fullName;
        Office = office;
        Specialty = specialty;
        District = district;
    }

    public Doctor(long id, string fullName, Office office, Specialty specialty, District district) :
        this(fullName, office, specialty, district)
    {
        Id = id;
    }

    public string FullName { get; set; }
    public Office Office { get; set; }
    public Specialty Specialty { get; set; }
    public District District { get; set; }
}
