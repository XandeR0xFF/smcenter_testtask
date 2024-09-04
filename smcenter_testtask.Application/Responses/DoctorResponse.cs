namespace smcenter_testtask.Application.Responses;

public class DoctorResponse
{
    public long Id { get; set; }
    public string FullName { get; set; } = String.Empty;
    public int OfficeNumber { get; set; }
    public string SpecialtyTitle { get; set; } = String.Empty;
    public int DistrictNumber { get; set; }
}
