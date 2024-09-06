using Microsoft.EntityFrameworkCore;
using smcenter_testtask.Domain.Aggregates.Districts;
using smcenter_testtask.Domain.Aggregates.Doctors;
using smcenter_testtask.Domain.Aggregates.Offices;
using smcenter_testtask.Domain.Aggregates.Patients;
using smcenter_testtask.Domain.Aggregates.Specialties;
using smcenter_testtask.Domain.Primitives;

namespace smcenter_testtask.Infrastructure
{
    public class DatabaseContext : DbContext, IUnitOfWork
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<District> Districts => Set<District>();
        public DbSet<Doctor> Doctors => Set<Doctor>();
        public DbSet<Office> Offices => Set<Office>();
        public DbSet<Patient> Patients => Set<Patient>();
        public DbSet<Specialty> Specialties => Set<Specialty>();
    }
}
