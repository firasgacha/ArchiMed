using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ArchiMed.Models;

public class MedicalOrder
{
    public int  MedicalOrderId { get; set; }
    public string  MedicalOrderDescription { get; set; }
    public string  MedicalOrderDate { get; set; }
    
    
    public Doctor? Doctor { get; set; }
    
    public int DoctorId { get; set; }
    
    public Patient? Patient { get; set; }
    
    public int PatientId { get; set; }
    
    public ICollection<Medications>Medications  { get; set; }
    
}