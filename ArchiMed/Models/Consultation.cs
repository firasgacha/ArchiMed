using System.ComponentModel.DataAnnotations.Schema;

namespace ArchiMed.Models;

public class Consultation
{
    public int ConsultationId { get; set; }
    public DateTime DateRendezVous { get; set; }
    
    //Les relations entre les tables
    public virtual Patient Patient { get; set; }
    
    public virtual Medecin Medecin { get; set; }
    
    [ForeignKey("Patient")]
    public int PatientFk { get; set; }
    
    [ForeignKey("Medecin")]
    public int MedecinFk { get; set; }
    
}