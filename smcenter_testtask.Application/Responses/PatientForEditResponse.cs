namespace smcenter_testtask.Application.Responses;

public class PatientForEditResponse
{
    public long Id { get; set; }
    public string FirstName { get; set; } = String.Empty;
    public string LastName { get; set; } = String.Empty;
    public string PatronymicName { get; set; } = String.Empty;
    public string Address { get; set; } = String.Empty;
    public string Sex { get; set; } = String.Empty;
    public long DistrictId { get; set; }
}
