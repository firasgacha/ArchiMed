using System.ComponentModel.DataAnnotations.Schema;

namespace ArchiMed.Models;

public class Ordenance
{
    public int  OrdenanceId { get; set; }
    public string  OrdenanceName { get; set; }
    public string  OrdenanceDescription { get; set; }
    public string  OrdenanceDate { get; set; }
    
    //Les relations entre les tables
    public virtual Medecin Medecin { get; set; }
    
    [ForeignKey("Medecin")]
    public int MedecinFk { get; set; }
    
    public virtual IList<Medicaments> MedicamentsList { get; set; }
    
    public virtual DossierMedical DossierMedical { get; set; }
    
    [ForeignKey("DossierMedical")]
    public int DossierMedicalFk { get; set; }
}