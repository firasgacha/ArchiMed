using System.ComponentModel.DataAnnotations.Schema;

namespace ArchiMed.Models;

public class ChefService : Patient
{
    public virtual Service Service { get; set; }
    
    [ForeignKey("Service")]
    public int ServiceFk { get; set; }
}