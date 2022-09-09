namespace ArchiMed.Models;

public class Agent
{
    public int ResponsableId { get; set; }
    public string nom { get; set; }
    public string prenom { get; set; }
    public string naissance { get; set; }
    public int cin { get; set; }
    public string adresse { get; set; }
    public string ville { get; set; }
    public string pays { get; set; }
    public int zipcode { get; set; }
    public string email { get; set; }
    public string mdp { get; set; }
    public string telephone { get; set; }
    public string ProfileUrl { get; set; }
    public string ProfileImage { get; set; }
    public TypeResponsable type { get; set; }
    
    public virtual IList<Consultation> ConsultationsList { get; set; }

    public virtual IList<Scanner> ScannersList { get; set; }

    public virtual IList<Radio> RadiosList { get; set; }
}