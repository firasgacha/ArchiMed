using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Text.Json.Serialization;

namespace ArchiMed.Models;

public class Medecin
{
    public int MedecinId { get; set; }
    public string nom { get; set; }
    public string prenom { get; set; }
    public DateTime naissance { get; set; }
    public int cin { get; set; }
    public string adresse { get; set; }
    public string ville { get; set; }
    public string pays { get; set; }
    public int zipcode { get; set; }
    public string email { get; set; }
    public string mdp { get; set; }
    public Specialite specialite { get; set; }
    public int telephone { get; set; }
    public bool chefDeProjet { get; set; }
    public string ProfileUrl { get; set; }
    public string ProfileImage { get; set; }
    
    //Les relations entre les tables
    public virtual IList<Consultation> ConsultationList { get; set; }
    public virtual IList<Service> ServicesList { get; set; }    
    public virtual IList<Ordenance> OrdenanceList { get; set; }

}