using smcenter_testtask.Domain.Primitives;

namespace smcenter_testtask.Domain.Aggregates.Districts;

public class District : Entity
{
    public District()
    {
    }

    public District(long id, int number)
    {
        Id = id;
        Number = number;
    }

    public int Number { get; set; }
}
