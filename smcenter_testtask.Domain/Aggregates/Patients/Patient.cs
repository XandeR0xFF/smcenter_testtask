using smcenter_testtask.Domain.Aggregates.Districts;
using smcenter_testtask.Domain.Primitives;
using System.Net;

namespace smcenter_testtask.Domain.Aggregates.Patients;

public class Patient : Entity
{
    private Patient()
    {
    }

    public Patient(string firstName, string lastName, string patronymicName, string address, string sex, District district)
    {
        FirstName = firstName;
        LastName = lastName;
        PatronymicName = patronymicName;
        Address = address;
        Sex = sex;
        District = district;
    }

    public Patient(long id, string firstName, string lastName, string patronymicName, string address, string sex, District district)
        : this(firstName, lastName, patronymicName, address, sex, district)
    {
        Id = id;
    }

    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string PatronymicName { get; set; }
    public string Address { get; set; }
    public string Sex { get; set; }
    public District District { get; set; }
}
