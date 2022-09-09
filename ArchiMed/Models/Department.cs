using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ArchiMed.Models;

public class Department
{
    public int DepartmentId { get; set; }
    public string departmentName { get; set; } 
    
    public List<Doctor> DoctorsList { get; set; }
}