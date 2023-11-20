namespace BackEnd.API.Credit.Domain.Models;

public class Entidad
{
    public int Id { get; set; }
    public string Name { get; set; }
    public double Comision { get; set; }
    public double SeguroDeg { get; set; }
    public double SeguroVehi { get; set; }
    public double TasaMin { get; set; }
    public double TasaMax { get; set; }
}