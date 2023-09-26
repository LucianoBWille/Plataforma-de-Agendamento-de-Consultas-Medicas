using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace Domain;
public class Specialty
{
    public long? SpecialtyID { get; set; }

    [Display(Name = "Nome da especialidade")]
    public string? SpecialtyName { get; set; }
    
    [Display(Name = "Descrição")]
    public string? Description { get; set; }
}