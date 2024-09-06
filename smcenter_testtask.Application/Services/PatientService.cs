using smcenter_testtask.Application.Requests;
using smcenter_testtask.Application.Responses;
using smcenter_testtask.Domain.Aggregates.Districts;
using smcenter_testtask.Domain.Aggregates.Patients;

namespace smcenter_testtask.Application.Services;

public class PatientService(IPatientRepository patientRepository, IDistrictRepository districtRepository)
{
    IPatientRepository _patientRepository = patientRepository;
    IDistrictRepository _districtRepository = districtRepository;

    public async Task Create(CreatePatientRequest request)
    {
        District? district = await _districtRepository.GetByIdAsync(request.DistrictId);
        if (district == null)
            throw new Exception("District Id not found.");

        Patient patient = new Patient(
            firstName: request.FirstName,
            lastName: request.LastName,
            patronymicName: request.PatronymicName,
            address: request.Address,
            sex: request.Sex,
            district: district
            );

        _patientRepository.Add(patient);
        await _patientRepository.UnitOfWork.SaveChangesAsync();
    }

    public async Task Update(long id, UpdatePatientRequest request)
    {
        Patient? patient = await _patientRepository.GetByIdAsync(id);
        if (patient == null)
            throw new Exception("Patient Id not found.");

        District? district = await _districtRepository.GetByIdAsync(request.DistrictId);
        if (district == null)
            throw new Exception("District Id not found.");

        patient.FirstName = request.FirstName;
        patient.LastName = request.LastName;
        patient.PatronymicName = request.PatronymicName;
        patient.Address = request.Address;
        patient.District = district;
        patient.Sex = request.Sex;

        await _patientRepository.UnitOfWork.SaveChangesAsync();
    }

    public async Task Delete(long id)
    {
        Patient? patient = await _patientRepository.GetByIdAsync(id);
        if (patient == null)
            throw new Exception("Id not found.");

        _patientRepository.Delete(patient);
        await _patientRepository.UnitOfWork.SaveChangesAsync();
    }

    public async Task<PatientForEditResponse> GetForEditByIdAsync(long id)
    {
        Patient? patient = await _patientRepository.GetByIdAsync(id);
        if (patient == null)
            throw new Exception("Patient Id not found.");

        PatientForEditResponse response = new PatientForEditResponse()
        {
            Id = patient.Id,
            FirstName = patient.FirstName,
            LastName = patient.LastName,
            PatronymicName = patient.PatronymicName,
            Address = patient.Address,
            Sex = patient.Sex.ToString(),
            DistrictId = patient.District.Id
        };

        return response;
    }

    public async Task<IEnumerable<PatientResponse>> GetAll(int page, int pageSize, string? orderBy)
    {
        IEnumerable<Patient> patients = await _patientRepository.GetAllAsync(page, pageSize, orderBy);
        List<PatientResponse> responses = new List<PatientResponse>();

        foreach (Patient patient in patients)
        {
            PatientResponse response = new PatientResponse()
            {
                Id = patient.Id,
                FirstName = patient.FirstName,
                LastName = patient.LastName,
                PatronymicName = patient.PatronymicName,
                Address = patient.Address,
                Sex = patient.Sex.ToString(),
                DistrictNumber = patient.District.Number
            };
            responses.Add(response);
        }

        return responses;
    }
}
