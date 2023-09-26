using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server;

public class ConsultationConfiguration : IEntityTypeConfiguration<Consultation>
{
    public void Configure(EntityTypeBuilder<Consultation> builder)
    {
        builder.HasKey(p=>p.ConsultationID);
        builder.Property(p=>p.Patient).IsRequired();
        builder.Property(p=>p.Doctor).IsRequired();
        builder.Property(p=>p.Receptionist).IsRequired();
        builder.Property(p=>p.dateTime).IsRequired();
        builder.Property(p=>p.ConsultationType).IsRequired();
    }
}