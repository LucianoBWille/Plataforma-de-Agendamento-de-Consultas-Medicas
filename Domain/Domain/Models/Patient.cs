using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Domain;
public class Patient
{
    public long? PatientID { get; set; }

    [Display(Name = "Nome")]
    public string? FirstName { get; set; }

    [Display(Name = "Sobrenome")]
    public string? LastName { get; set; }

    [Display(Name = "Número de identificação")]
    public int? IdentificationNumber { get; set; }

//     [Display(Name = "Histórico médico")]
//     public List<Consutation>? MedicalHistory { get; set; }
}