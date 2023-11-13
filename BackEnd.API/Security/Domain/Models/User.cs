using System.Text.Json.Serialization;
using BackEnd.API.Credit.Domain.Models;

namespace BackEnd.API.Security.Domain.Models;

public class User
{
    public int Id { get; set; }
    
    public string Nombre { get; set; }
    
    public string Apellido { get; set; }
    
    public string Dni { get; set; }
    
    public string Telefono { get; set; }
    
    public string Email { get; set; }
    
    public Vehicle Vehicle { get; set; }
    
    public Credito Credito { get; set; }
    
    [JsonIgnore]
    public string PasswordHash { get; set; }
    
}