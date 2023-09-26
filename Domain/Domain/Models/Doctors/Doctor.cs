using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Domain;
public class Doctor
{
    public long? DoctorID { get; set; }

    [Display(Name = "Nome")]
    public string? Name { get; set; }

    [Display(Name = "Número de registro profissional")]
    [Range(1, int.MaxValue, ErrorMessage = "Por favor insira um valor maior que 0")]
    public int? ProfesssionalRegistrationNumber { get; set; }

    [Display(Name = "Horários disponíveis")]
    public List<TimeRange>? AvailableHours { get; set; }

    [Display(Name = "Especialidade")]
    public Specialty? Specialty { get; set; }

    // [Display(Name = "Consultas")]
    // public List<Consultation>? Consultations { get; set; }
}