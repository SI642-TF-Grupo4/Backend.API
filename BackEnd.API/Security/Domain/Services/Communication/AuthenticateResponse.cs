namespace BackEnd.API.Security.Domain.Services.Communication;

public class AuthenticateResponse
{
    public int Id { get; set; }
    public string Nombre { get; set; }
    public string Apellido { get; set; }
    public string Dni { get; set; }
    public string Email { get; set; }
    public string Telefono { get; set; }
    public string Token { get; set; }
}