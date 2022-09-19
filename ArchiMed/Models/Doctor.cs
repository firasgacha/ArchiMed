using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;
using Microsoft.VisualBasic;

namespace ArchiMed.Models;

public class Doctor : User
{
    public int DoctorId { get; set; }
    public string specialty { get; set; }
    public bool headofDepartment { get; set; } = false;
    
    public int DepartmentFk { get; set; }
}