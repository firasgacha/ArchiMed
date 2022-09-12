namespace ArchiMed.Models;

public class Medications
{
    public int MedicationsId { get; set; }
    public string medicationName { get; set; }
    public string medicationDescription { get; set; }
    public string medicationComposition { get; set; }
    public string medicationEffets { get; set; }
    public string medicationContraindication { get; set; }
    public int medicationPrice { get; set; }
    public string medicationCode { get; set; }
    public string DateFabrication { get; set; }
    public string DateExpiration { get; set; }
}