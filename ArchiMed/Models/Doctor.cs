using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ArchiMed.Models;

public class Doctor
{
    public int DoctorId { get; set; }
    public string fisrtName { get; set; }
    public string lastName { get; set; }
    public DateTime birthday { get; set; }
    public int cin { get; set; }
    public string adress { get; set; }
    public string city { get; set; }
    public string country { get; set; }
    public int postalCode { get; set; }
    public string email { get; set; }
    public Specialite specialty { get; set; }
    public int phone { get; set; }
    public bool headofDepartment { get; set; }

    //Les relations entre les tables
    public virtual IList<Consultation> ConsultationList { get; set; }
    public virtual IList<Service> ServicesList { get; set; }    
    public virtual IList<Ordenance> OrdenanceList { get; set; }

}