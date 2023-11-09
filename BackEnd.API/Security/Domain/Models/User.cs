using System.Text.Json.Serialization;

namespace BackEnd.API.Security.Domain.Models;

public class User
{
    public int Id { get; set; }
    
    public string Nombre { get; set; }
    
    public string Apellido { get; set; }
    
    public string Dni { get; set; }
    
    public string Telefono { get; set; }
    
    public string Email { get; set; }
    
    [JsonIgnore]
    public string PasswordHash { get; set; }
    
}