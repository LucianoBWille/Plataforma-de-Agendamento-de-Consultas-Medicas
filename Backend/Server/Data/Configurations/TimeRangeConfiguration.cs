using Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Server;

public class TimeRangeConfiguration : IEntityTypeConfiguration<TimeRange>
{
    public void Configure(EntityTypeBuilder<TimeRange> builder)
    {
        builder.HasKey(p=>p.TimeRangeID);
        builder.Property(p=>p.StartTime).IsRequired();
        builder.Property(p=>p.EndTime).IsRequired();
    }
}