using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ArchiMed.Models;

public class Scanner
{
    public int ScannerId { get; set; }
    
    public string Description { get; set; }
    
    public string Created { get; set; }
    
    public Doctor? Doctor { get; set; }
    
    public int DoctorId { get; set; }
    
    public Patient? Patient { get; set; }
    
    public int PatientId { get; set; }
    
    public Agent? Agent { get; set; }
    
    public int AgentId { get; set; }
   
}