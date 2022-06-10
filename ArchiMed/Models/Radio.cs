using System.ComponentModel.DataAnnotations.Schema;

namespace ArchiMed.Models;

public class Radio
{
    public int RadioId { get; set; }
    public string RadioName { get; set; }
    public string RadioDescription { get; set; }
    public string RadioUrl { get; set; }
    public string RadioImage { get; set; }
    public string RadioType { get; set; }

    //Les relations entre les tables
    public virtual DossierMedical DossierMedical { get; set; }
    
    [ForeignKey("DossierMedical")]
    public int DossierMedicalFk { get; set; }
}