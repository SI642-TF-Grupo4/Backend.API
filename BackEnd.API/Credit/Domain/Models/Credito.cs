using BackEnd.API.Security.Domain.Models;

namespace BackEnd.API.Credit.Domain.Models;

public class Credito
{
    public int Id { get; set; }
    public double PrecioVenta { get; set; }
    public double MontoFinanciar { get; set; }
    public int Plazo { get; set; }//en años, la frecuencia de pago es mensual
    //se considera un año 360 dias 
    public int TotalPeriodos { get; set; }
    public double Tea { get; set; }
    public string Moneda { get; set; }
    public int PeriodosGraciaTotal { get; set; }
    public int PeriodosGraciaParcial { get; set; }
    public double TasaSeguroDesgravamen { get; set; }
    public double MontoSeguroDesgravamen { get; set; }
    public double TasaInteresMoratorio { get; set; }
    public double ComisionEnvioFisico { get; set; }
    public double TasaSeguroVehicular { get; set; }
    public double MontoSeguroVehicular { get; set; }
    public DateTime FechaPrimeraCuota { get; set; }
    public DateTime FechaDesembolso { get; set; }
    public double OtrosGastos { get; set; }
    public double OtrasComisiones { get; set; }
    public int UserId { get; set; }
    public User User;

}