using System.ComponentModel.DataAnnotations;

namespace ArchiMed.Models;

public class User
{
    [Key]
    public int id { get; set; }
    public string fisrtName { get; set; }
    [DataType(DataType.Password)]
    public string password { get; set; }
    public string lastName { get; set; }
    public string birthday { get; set; }
    public string gender { get; set; }
    public int cin { get; set; }
    public string address { get; set; }
    public string city { get; set; }
    public string country { get; set; }
    public int postalCode { get; set; }
    [DataType(DataType.EmailAddress)]
    public string email { get; set; }
    [DataType(DataType.PhoneNumber)]
    public string phone { get; set; }
    public string ImageUrl { get; set; }
}
