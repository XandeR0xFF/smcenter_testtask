using smcenter_testtask.Application.Requests;
using smcenter_testtask.Application.Responses;
using smcenter_testtask.Domain.Aggregates.Districts;
using smcenter_testtask.Domain.Aggregates.Doctors;
using smcenter_testtask.Domain.Aggregates.Offices;
using smcenter_testtask.Domain.Aggregates.Specialties;
using System.Numerics;

namespace smcenter_testtask.Application.Services
{
    public class DoctorService(
        IDoctorRepository doctorRepository,
        IOfficeRepository officeRepository,
        ISpecialtyRepository specialtyRepository,
        IDistrictRepository districtRepository)
    {
        private readonly IDoctorRepository _doctorRepository = doctorRepository;
        private readonly IOfficeRepository _officeRepository = officeRepository;
        private readonly ISpecialtyRepository _specialtyRepository = specialtyRepository;
        private readonly IDistrictRepository _districtRepository = districtRepository;


        public async Task Create(CreateDoctorRequest request)
        {
            Office? office = await _officeRepository.GetByIdAsync(request.OfficeId);
            if (office == null)
                throw new Exception("Office Id not found.");

            Specialty? specialty = await _specialtyRepository.GetByIdAsync(request.SpecialtyId);
            if (specialty == null)
                throw new Exception("Specialty Id not found.");

            District? district = await _districtRepository.GetByIdAsync(request.DistrictId);
            if (district == null)
                throw new Exception("District Id not found.");

            Doctor doctor = new Doctor(
                fullName: request.FullName,
                office: office,
                specialty: specialty,
                district: district);

            _doctorRepository.Add(doctor);

            await _doctorRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task Update(long id, UpdateDoctorRequest request)
        {
            Doctor? doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null)
                throw new Exception("Id not found.");

            Office? office = await _officeRepository.GetByIdAsync(request.OfficeId);
            if (office == null)
                throw new Exception("Office Id not found.");

            Specialty? specialty = await _specialtyRepository.GetByIdAsync(request.SpecialtyId);
            if (specialty == null)
                throw new Exception("Specialty Id not found.");

            District? district = await _districtRepository.GetByIdAsync(request.DistrictId);
            if (district == null)
                throw new Exception("District Id not found.");

            doctor.FullName = request.FullName;
            doctor.Office = office;
            doctor.Specialty = specialty;
            doctor.District = district;

            await _doctorRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            Doctor? doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null)
                throw new Exception("Doctor Id not found.");

            _doctorRepository.Delete(doctor);
            await _doctorRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task<DoctorForEditResponse> GetForEditByIdAsync(long id)
        {
            Doctor? doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null)
                throw new Exception("Doctor Id not found.");

            DoctorForEditResponse response = new DoctorForEditResponse()
            {
                Id = doctor.Id,
                FullName = doctor.FullName,
                OfficeId = doctor.Office.Id,
                SpecialtyId = doctor.Specialty.Id,
                DistrictId = doctor.District.Id
            };

            return response;
        }

        public async Task<IEnumerable<DoctorResponse>> GetAll(int page, int pageSize, string? orderBy)
        {
            IEnumerable<Doctor> doctors = await _doctorRepository.GetAllAsync(page, pageSize, orderBy);
            List<DoctorResponse> responses = new List<DoctorResponse>();

            foreach (Doctor doctor in doctors)
            {
                DoctorResponse response = new DoctorResponse()
                {
                    Id = doctor.Id,
                    FullName = doctor.FullName,
                    OfficeNumber = doctor.Office.Number,
                    SpecialtyTitle = doctor.Specialty.Title,
                    DistrictNumber = doctor.District.Number
                };
                responses.Add(response);
            }

            return responses;
        }
    }
}
