namespace smcenter_testtask.Application.Requests;

public class CreateDoctorRequest
{
    public string FullName { get; set; } = String.Empty;
    public long OfficeId { get; set; }
    public long SpecialtyId { get; set; }
    public long DistrictId { get; set; }
}
