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
            Office office = await _officeRepository.GetByIdAsync(request.OfficeId);
            if (office == null)
                throw new Exception("Office Id not found.");

            Specialty specialty = await _specialtyRepository.GetByIdAsync(request.SpecialtyId);
            if (specialty == null)
                throw new Exception("Specialty Id not found.");

            District district = await _districtRepository.GetByIdAsync(request.DistrictId);
            if (district == null)
                throw new Exception("District Id not found.");

            Doctor doctor = new Doctor();
            doctor.FullName = request.FullName;
            doctor.OfficeId = office.Id;
            doctor.SpecialtyId = specialty.Id;
            doctor.DistrictId = district.Id;

            _doctorRepository.Add(doctor);

            await _doctorRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task Update(long id, UpdateDoctorRequest request)
        {
            Doctor doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null)
                throw new Exception("Id not found.");

            Office office = await _officeRepository.GetByIdAsync(request.OfficeId);
            if (office == null)
                throw new Exception("Office Id not found.");

            Specialty specialty = await _specialtyRepository.GetByIdAsync(request.SpecialtyId);
            if (specialty == null)
                throw new Exception("Specialty Id not found.");

            District district = await _districtRepository.GetByIdAsync(request.DistrictId);
            if (district == null)
                throw new Exception("District Id not found.");

            doctor.FullName = request.FullName;
            doctor.OfficeId = office.Id;
            doctor.SpecialtyId = specialty.Id;
            doctor.DistrictId = district.Id;

            await _doctorRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task Delete(long id)
        {
            Doctor doctor = await _doctorRepository.GetByIdAsync(id);
            if (doctor == null)
                throw new Exception("Doctor Id not found.");

            _doctorRepository.Delete(doctor);
            await _doctorRepository.UnitOfWork.SaveChangesAsync();
        }

        public async Task<DoctorForEditResponse> GetForEditByIdAsync(long id)
        {
            Doctor doctor = await _doctorRepository.GetByIdAsync(id);

            DoctorForEditResponse response = new DoctorForEditResponse()
            {
                Id = doctor.Id,
                FullName = doctor.FullName,
                OfficeId = doctor.OfficeId,
                SpecialtyId = doctor.SpecialtyId,
                DistrictId = doctor.DistrictId
            };

            return response;
        }

        public async Task<IEnumerable<DoctorResponse>> GetAll(long page, long pageSize, string orderBy)
        {
            IEnumerable<Doctor> doctors = await _doctorRepository.GetAllAsync(page, pageSize, orderBy);
            List<DoctorResponse> responses = new List<DoctorResponse>();

            foreach (Doctor doctor in doctors)
            {
                Office office = await _officeRepository.GetByIdAsync(doctor.OfficeId);
                if (office == null)
                    throw new Exception("Office Id not found.");

                Specialty specialty = await _specialtyRepository.GetByIdAsync(doctor.SpecialtyId);
                if (specialty == null)
                    throw new Exception("Specialty Id not found.");

                District district = await _districtRepository.GetByIdAsync(doctor.DistrictId);
                if (district == null)
                    throw new Exception("District Id not found.");

                DoctorResponse response = new DoctorResponse()
                {
                    Id = doctor.Id,
                    FullName = doctor.FullName,
                    OfficeNumber = office.Number,
                    SpecialtyTitle = specialty.Title,
                    DistrictNumber = district.Number
                };
                responses.Add(response);
            }

            return responses;
        }
    }
}
