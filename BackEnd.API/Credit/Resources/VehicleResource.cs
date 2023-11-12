using BackEnd.API.Security.Resources;

namespace BackEnd.API.Credit.Resources;

public class VehicleResource
{
    public int Id { get; set; }
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Tipo { get; set; }
    public double Monto { get; set; }
    public UserResource User { get; set; }
}