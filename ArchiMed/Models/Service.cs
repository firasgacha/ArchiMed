using System.ComponentModel.DataAnnotations.Schema;

namespace ArchiMed.Models;

public class Service
{
    public int ServiceId { get; set; }
    public string nom { get; set; } 
    
    
    public virtual ChefService ChefService { get; set; }
    
    [ForeignKey("ChefService")]
    public int ChefServiceFk { get; set; }
    
    public virtual IList<Medecin> MedecinsList { get; set; }
}