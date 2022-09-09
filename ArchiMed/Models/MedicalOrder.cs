using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ArchiMed.Models;

public class MedicalOrder
{
    public int  MedicalOrderId { get; set; }
    public string  MedicalOrderName { get; set; }
    public string  MedicalOrderDescription { get; set; }
    public string  MedicalOrderDate { get; set; }
    
    //Les relations entre les tables
    [JsonIgnore]
    public virtual Doctor doctor { get; set; }
    
    [ForeignKey("doctor")]
    public int DoctorFk { get; set; }
    
    public virtual IList<Medications> MedicationsList { get; set; }
    
    [JsonIgnore]
    public virtual MedicalFolder medicalFolder { get; set; }
    
    [ForeignKey("medicalFolder")]
    public int DossierMedicalFk { get; set; }
}