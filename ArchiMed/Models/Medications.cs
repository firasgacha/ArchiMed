namespace ArchiMed.Models;

public class Medications
{
    public int MedicationsId { get; set; }
    public string medicationName { get; set; }
    public string medicationDescription { get; set; }
    public string medicationComposition { get; set; }
    public string medicationEffets { get; set; }
    public string medicationcontraindication { get; set; }
    public string medicationPrice { get; set; }
    public string medicationPicture { get; set; }
    public string medicationCode { get; set; }
    public DateTime DateFabrication { get; set; }
    public DateTime DateExpiration { get; set; }
}