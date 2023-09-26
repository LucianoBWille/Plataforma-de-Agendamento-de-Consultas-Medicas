using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Domain;
public class Consultation
{
    public long? ConsultationID { get; set; }

    [Display(Name = "Paciente")]
    public Patient? Patient { get; set; }

    [Display(Name = "Médico")]
    public Doctor? Doctor { get; set; }

    [Display(Name = "Recepcionista")]
    public Receptionist? Receptionist { get; set; }

    [Display(Name = "Data e hora")]
    public DateTime? dateTime { get; set; }

    [Display(Name = "Observações")]
    public string? Observations { get; set; }
    
    [RegularExpression("in-person|online")]
    [Display(Name = "Tipo de Consulta")]
    public string? ConsultationType { get; set; }
}