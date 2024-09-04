using smcenter_testtask.Domain.Primitives;

namespace smcenter_testtask.Domain.Aggregates.Offices;

public class Office : Entity
{
    public Office()
    {
    }

    public Office(long id, int number)
    {
        Id = id;
        Number = number;
    }

    public int Number { get; set; }
}
