using Domain;
using Microsoft.EntityFrameworkCore;

namespace Server;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        :base(options)
    {
        
    }
    public DbSet<Doctor> Doctors { get; set; }
    public DbSet<Patient> Patients { get; set; }
    public DbSet<Specialty> Specialties { get; set; }
    public DbSet<Receptionist> Receptionists { get; set; }
    public DbSet<Consultation> Consultations { get; set; }
    public DbSet<TimeRange> TimeRanges { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        // modelBuilder.ApplyConfiguration(new DoctorConfiguration());
        // modelBuilder.ApplyConfiguration(new PatientConfiguration());
        // modelBuilder.ApplyConfiguration(new SpecialtyConfiguration());
        // modelBuilder.ApplyConfiguration(new ReceptionistConfiguration());
        // modelBuilder.ApplyConfiguration(new ConsultationConfiguration());
    }

}