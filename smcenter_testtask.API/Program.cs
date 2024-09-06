
using Microsoft.EntityFrameworkCore;
using smcenter_testtask.Application.Services;
using smcenter_testtask.Domain.Aggregates.Districts;
using smcenter_testtask.Domain.Aggregates.Doctors;
using smcenter_testtask.Domain.Aggregates.Offices;
using smcenter_testtask.Domain.Aggregates.Patients;
using smcenter_testtask.Domain.Aggregates.Specialties;
using smcenter_testtask.Infrastructure;
using smcenter_testtask.Infrastructure.Repositories;

namespace smcenter_testtask.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddDbContext<DatabaseContext>(options => 
                options.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=smcenter_testtaskdb;Trusted_Connection=True;"));

            builder.Services.AddScoped<IDoctorRepository, DoctorRepository>();
            builder.Services.AddScoped<IDistrictRepository, DistrictRepository>();
            builder.Services.AddScoped<IOfficeRepository, OfficeRepository>();
            builder.Services.AddScoped<ISpecialtyRepository, SpecialtyRepository>();
            builder.Services.AddScoped<IPatientRepository, PatientRepository>();

            builder.Services.AddScoped<DoctorService>();
            builder.Services.AddScoped<PatientService>();

            var app = builder.Build();
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseAuthorization();
            app.MapControllers();
            app.Run();
        }
    }
}
