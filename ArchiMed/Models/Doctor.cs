using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;

namespace ArchiMed.Models;

public class Doctor
{
    public int DoctorId { get; set; }
    public string fisrtName { get; set; }
    public string lastName { get; set; }
    public string gender { get; set; }
    public string birthday { get; set; }
    public int cin { get; set; }
    public string adress { get; set; }
    public string city { get; set; }
    public string country { get; set; }
    public int postalCode { get; set; }
    public string email { get; set; }
    public string specialty { get; set; }
    public string phone { get; set; }
    public bool headofDepartment { get; set; } = false;
    
    public string ImageUrl { get; set; }
    
    
    public Department? Department { get; set; }
    
    public int DepartmentFk { get; set; }
    
}