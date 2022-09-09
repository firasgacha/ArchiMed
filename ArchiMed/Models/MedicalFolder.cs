using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ArchiMed.Models;

public class MedicalFolder
{
    [Key]
    public int FolderNumber { get; set; }
    
    [JsonIgnore]
    public virtual Patient patient { get; set; }
    
    [ForeignKey("patient")]
    public int PatientFk { get; set; }
    
}