namespace smcenter_testtask.Domain.Aggregates.Patients;

public class Sex
{
    private const string MaleValue = "М";
    private const string FemaleValue = "Ж";

    private readonly string _value;

    private static readonly Sex _male = new Sex(MaleValue);
    private static readonly Sex _female = new Sex(FemaleValue);

    public static Sex Male => _male;
    public static Sex Female => _female;
    public static Sex FromValue(string value)
    {
        switch (value)
        {
            case MaleValue:
                return _male;
            case FemaleValue:
                return _female;
            default:
                throw new ArgumentException($"Incorrect sex value: {value}");
        }
    }

    private Sex(string value)
    {
        _value = value;
    }

    public string Value => _value;

    public override string ToString()
    {
        return _value;
    }
}
