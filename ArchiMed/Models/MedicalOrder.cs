using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ArchiMed.Models;

public class MedicalOrder
{
    public int  MedicalOrderId { get; set; }
    public string  MedicalOrderName { get; set; }
    public string  MedicalOrderDescription { get; set; }
    public string  MedicalOrderDate { get; set; }
}