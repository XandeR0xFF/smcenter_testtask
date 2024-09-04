using smcenter_testtask.Domain.Primitives;
using System.Net;

namespace smcenter_testtask.Domain.Aggregates.Patients;

public class Patient : Entity
{
    public Patient(string firstName, string lastName, string patronymicName, string address, Sex sex, long districtId)
    {
        FirstName = firstName;
        LastName = lastName;
        PatronymicName = patronymicName;
        Address = address;
        Sex = sex;
        DistrictId = districtId;
    }

    public Patient(long id, string firstName, string lastName, string patronymicName, string address, Sex sex, long districtId)
        : this(firstName, lastName, patronymicName, address, sex, districtId)
    {
        Id = id;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PatronymicName { get; set; }
    public string Address { get; set; }
    public Sex Sex { get; set; }
    public long DistrictId { get; set; }
}
