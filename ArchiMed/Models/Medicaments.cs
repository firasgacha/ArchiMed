namespace ArchiMed.Models;

public class Medicaments
{
    public int MedicamentsId { get; set; }
    public string Nom { get; set; }
    public string Description { get; set; }
    public string Composition { get; set; }
    public string Effets { get; set; }
    public string ContreIndications { get; set; }
    public string Prix { get; set; }
    public string Image { get; set; }
    public string Url { get; set; }
    public string Code { get; set; }
    public string CodeBarre { get; set; }
    public DateTime DateFabrication { get; set; }
    public DateTime DateExpiration { get; set; }
}