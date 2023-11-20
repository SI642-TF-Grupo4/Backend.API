using BackEnd.API.Credit.Resources;

namespace BackEnd.API.Security.Resources;

public class UserResource
{
    public int Id { get; set; }
    
    public string Nombre { get; set; }
    
    public string Apellido { get; set; }
    
    public string Dni { get; set; }
    
    public string Telefono { get; set; }
    
    public string Email { get; set; }
    
    public string Password { get; set; }
}