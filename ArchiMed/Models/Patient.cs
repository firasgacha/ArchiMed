using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ArchiMed.Models;

public class Patient
{
    public int PatientId { get; set; }
    
    public MedicalFolder? MedicalFolder { get; set; }
    
    public int MedicalFolderId { get; set; }
    
}