using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ArchiMed.Models;

public class Department
{
    //create constructor
    public int DepartmentId { get; set; }
    public string departmentName { get; set; } 
    
    public ICollection<Doctor> Doctors { get; set; }
}