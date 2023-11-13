using BackEnd.API.Security.Domain.Models;

namespace BackEnd.API.Credit.Domain.Models;

public class Vehicle
{
    public int Id { get; set; }
    public string Placa { get; set; }
    public string Marca { get; set; }
    public string Modelo { get; set; }
    public string Tipo { get; set; }
    public double Monto { get; set; }
    public int UserId { get; set; }
    public User User { get; set; }
}