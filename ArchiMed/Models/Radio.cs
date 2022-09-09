using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ArchiMed.Models;

public class Radio
{
    public int RadioId { get; set; }
    public string RadioName { get; set; }
    public string RadioDescription { get; set; }
    public string RadioType { get; set; }
    public DateTime Created { get; set; }
    
    //Les relations entre les tables
    [JsonIgnore]
    public virtual MedicalFolder medicalFolder { get; set; }
    
    [ForeignKey("medicalFolder")]
    public int medicalFolderFk { get; set; }
}