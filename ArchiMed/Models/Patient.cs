﻿using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace ArchiMed.Models;

public class Patient
{
    public int PatientId { get; set; }
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
    public string phone { get; set; }
    
    public MedicalFolder? MedicalFolder { get; set; }
    
    public int MedicalFolderId { get; set; }
    
}