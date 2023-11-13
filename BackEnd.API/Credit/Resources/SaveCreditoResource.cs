using System.ComponentModel.DataAnnotations;

namespace BackEnd.API.Credit.Resources;

public class SaveCreditoResource
{
    [Required]
    public double PrecioVenta { get; set; }
    public double CuotaInicial { get; set; }
    [Required]
    public double MontoFinanciar { get; set; }
    [Required]
    public int Plazo { get; set; }//en años, la frecuencia de pago es mensual
    //se considera un año 360 dias 
    [Required]
    public int TotalPeriodos { get; set; }
    [Required]
    public double Tea { get; set; }
    [Required]
    public string Moneda { get; set; }
    [Required]
    public int PeriodosGraciaTotal { get; set; }
    [Required]
    public int PeriodosGraciaParcial { get; set; }
    [Required]
    public double TasaSeguroDesgravamen { get; set; }
    [Required]
    public double TasaInteresMoratorio { get; set; }
    public double ComisionEnvioFisico { get; set; }
    [Required]
    public double TasaSeguroVehicular { get; set; }
    [Required]
    public string FechaPrimeraCuota { get; set; }
    [Required]
    public string FechaDesembolso { get; set; }
    public double OtrosGastos { get; set; }
    public double OtrasComisiones { get; set; }
    
    public double Tir { get; set; }
    public double Tcea { get; set; }
    public double CuotaMensual { get; set; }
    public double UltimaCuota { get; set; }
    
    [Required]
    public int UserId { get; set; }
}