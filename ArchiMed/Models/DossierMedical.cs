using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ArchiMed.Models;

public class DossierMedical
{
    [Key]
    public int NumeroDossier { get; set; }
    
    //Les relations entre les tables
    public virtual Patient Patient { get; set; }
    
    [ForeignKey("Patient")]
    public int PatientFk { get; set; }
    
    
    public virtual IList<Ordenance> OrdenanceList{ get; set; }
    
    public virtual IList<Radio> RadiosList{ get; set; }
    
    public virtual IList<Scanner> ScannersList{ get; set; }
    
}