using smcenter_testtask.Domain.Primitives;

namespace smcenter_testtask.Domain.Aggregates.Doctors;

public class Doctor : Entity
{
    public Doctor()
    {
        FullName = String.Empty;
    }

    public Doctor(long id, string fullName, long officeId, long specialtyId, long districtId)
    {
        Id = id;
        FullName = fullName;
        OfficeId = officeId;
        SpecialtyId = specialtyId;
        DistrictId = districtId;
    }

    public string FullName { get; set; }
    public long OfficeId { get; set; }
    public long SpecialtyId { get; set; }
    public long DistrictId { get; set; }
}
