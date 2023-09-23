namespace Domain;

public class Receptionist
{
    public long? ReceptionistID { get; set; }

    [Display(Name = "Nome")]
    public string? FirstName { get; set; }

    [Display(Name = "Sobrenome")]
    public string? LastName { get; set; }

    [Display(Name = "Número de identificação")]
    public int? IdentificationNumber { get; set; }

    [Display(Name = "Número de telefone")]
    public string? TelephoneNumber { get; set; }

    // [Display(Name = "Consultas")]
    // public List<Consultation>? Consultations { get; set; }
}