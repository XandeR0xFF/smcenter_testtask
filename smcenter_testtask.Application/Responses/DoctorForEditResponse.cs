namespace smcenter_testtask.Application.Responses;

public class DoctorForEditResponse
{
    public long Id { get; set; }
    public string FullName { get; set; } = String.Empty;
    public long OfficeId { get; set; }
    public long SpecialtyId { get; set; }
    public long DistrictId { get; set; }
}
