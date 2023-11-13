using System.ComponentModel.DataAnnotations;

namespace BackEnd.API.Credit.Resources;

public class SaveVehicleResource
{
    [Required]
    public string Placa { get; set; }
    [Required]
    public string Marca { get; set; }
    [Required]
    public string Modelo { get; set; }
    public string Tipo { get; set; }
    [Required]
    public double Monto { get; set; }
    [Required]
    public int UserId { get; set; }
}