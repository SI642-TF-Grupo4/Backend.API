using System.ComponentModel.DataAnnotations;

namespace BackEnd.API.Credit.Resources;

public class SaveCuotaResource
{
    [Required]
    public int NCuota { get; set; }
    public int TipoPeriodoGracia { get; set; } // Total, parcial, sin gracia
    public string Fecha { get; set; }
    [Required]
    public double SaldoInicial { get; set; }
    public double Interes { get; set; }
   [Required]
    public double Amortización { get; set; }
    public double MontoCuota { get; set; }
    [Required]
    public double SaldoFinal { get; set; }
    public double Comision { get; set; }
    public double SeguroDesgravamen { get; set; }
    public double SeguroVehicular { get; set; }
    [Required]
    public double FlujoDeCaja { get; set; }
    [Required]
    public int CreditoId { get; set; }
}