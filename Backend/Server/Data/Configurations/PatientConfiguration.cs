using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server;

public class PatientConfiguration : IEntityTypeConfiguration<Patient>
{
    public void Configure(EntityTypeBuilder<Patient> builder)
    {
        builder.HasKey(p=>p.PatientID);
        builder.Property(p=>p.FirstName).IsRequired();
        builder.Property(p=>p.LastName).IsRequired();
        builder.Property(p=>p.IdentificationNumber).IsRequired();
    }
}