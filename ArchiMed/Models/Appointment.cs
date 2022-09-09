using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ArchiMed.Models;

public class Appointment
{
    public int AppointmentId { get; set; }
    
    public DateTime AppointmentDate { get; set; }
    
    //Les relations entre les tables
    [JsonIgnore]    
    public virtual Patient patient { get; set; }
    
    [JsonIgnore]
    public virtual Doctor doctor { get; set; }
    
    [JsonIgnore]
    public virtual Agent agent { get; set; }
    
    [ForeignKey("agent")]
    public int AgentFk { get; set; }
    
    [ForeignKey("Patient")]
    public int PatientFk { get; set; }
    
    [ForeignKey("doctor")]
    public int DoctorFk { get; set; }
    
}