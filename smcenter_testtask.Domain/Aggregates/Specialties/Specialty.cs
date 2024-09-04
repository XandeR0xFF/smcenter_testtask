using smcenter_testtask.Domain.Primitives;

namespace smcenter_testtask.Domain.Aggregates.Specialties;

public class Specialty : Entity
{
    public Specialty()
    {
        Title = String.Empty;
    }

    public Specialty(long id, string title)
    {
        Id = id;
        Title = title;
    }

    public string Title { get; set; }
}
