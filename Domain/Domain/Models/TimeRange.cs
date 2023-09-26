using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Domain;
public class TimeRange
{
    public long? TimeRangeID { get; set; }

    [Display(Name = "Horário de início")]
    public DateTime StartTime { get; set; }

    [Display(Name = "Horário de término")]
    public DateTime EndTime { get; set; }

    // [Display(Name = "Duração")]
    // public TimeSpan? Duration { get; set; }

    // [Display(Name = "Dias da semana")]
    // public List<DayOfWeek>? DaysOfWeek { get; set; }
}