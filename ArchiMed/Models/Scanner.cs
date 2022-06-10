using System.ComponentModel.DataAnnotations.Schema;

namespace ArchiMed.Models;

public class Scanner
{
    public int ScannerId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public string ScannerType { get; set; }
    public string ScannerUrl { get; set; }
    public string ScannerImage { get; set; }
    
    //Les relations entre les tables
    public virtual DossierMedical DossierMedical { get; set; }
    
    [ForeignKey("DossierMedical")]
    public int DossierMedicalFk { get; set; }
}