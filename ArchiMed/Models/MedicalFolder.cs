using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ArchiMed.Models;

public class MedicalFolder
{
    public int MedicalFolderId { get; set; }
    
    public ICollection<Scanner> Scanners { get; set; }
    public ICollection<Radio> Radios { get; set; }
    public ICollection<MedicalOrder>MedicalOrders  { get; set; }
}