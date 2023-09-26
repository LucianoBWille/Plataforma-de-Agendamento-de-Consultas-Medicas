using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server;

public class DoctorConfiguration : IEntityTypeConfiguration<Doctor>
{
    public void Configure(EntityTypeBuilder<Doctor> builder)
    {
        builder.HasKey(p=>p.DoctorID);
        builder.Property(p=>p.Name).IsRequired();
        builder.Property(p=>p.ProfesssionalRegistrationNumber).IsRequired();
        builder.Property(p=>p.Specialty).IsRequired();

    }
}