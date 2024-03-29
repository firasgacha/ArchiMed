﻿using System.ComponentModel.DataAnnotations.Schema;

namespace ArchiMed.Models;

public class Patient
{
    public int PatientId { get; set; }
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
    
    //Les relations entre les tables
    public virtual IList<Consultation> ConsultationList { get; set; }
    
    public virtual DossierMedical DossierMedical { get; set; }
    
    [ForeignKey("DossierMedical")]
    public int DossierMedicalFk { get; set; }
}