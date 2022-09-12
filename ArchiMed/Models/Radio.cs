using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ArchiMed.Models;

public class Radio
{
    public int RadioId { get; set; }
    
    public string RadioDescription { get; set; }
    
    public string Created { get; set; }
    
    public Doctor? Doctor { get; set; }
    
    public int DoctorId { get; set; }
    
    public Patient? Patient { get; set; }
    
    public int PatientId { get; set; }
    
    public Agent? Agent { get; set; }
    
    public int AgentId { get; set; }
}