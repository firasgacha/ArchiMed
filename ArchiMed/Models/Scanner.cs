using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ArchiMed.Models;

public class Scanner
{
    public int ScannerId { get; set; }
    public string ScannerName { get; set; }
    public string Description { get; set; }
    public DateTime Created { get; set; }
    public string ScannerType { get; set; }
    
    //Les relations entre les tables
    [JsonIgnore]
    public virtual Agent agent { get; set; }
    
    [ForeignKey("agent")]
    public int AgentFk { get; set; }
    
    [JsonIgnore]
    public virtual MedicalFolder medicalFolder { get; set; }
    
    [ForeignKey("medicalFolder")]
    public int medicalFolderFk { get; set; }
}