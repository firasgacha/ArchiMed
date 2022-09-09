using System.ComponentModel.DataAnnotations.Schema;

namespace ArchiMed.Models;

public class Department
{
    public int DepartmentId { get; set; }
    public string departmentName { get; set; } 
    
    
    public virtual Doctor headofDepartment { get; set; }
    
    [ForeignKey("headofDepartment")]
    public int ChefServiceFk { get; set; }
    
    public virtual IList<Doctor> DoctorsList { get; set; }
}