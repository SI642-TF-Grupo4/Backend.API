using System.ComponentModel.DataAnnotations;

namespace BackEnd.API.Credit.Resources;

public class SaveCuotaResource
{
    public int NCuota;
    public int TipoPeriodoGracia; // Total, parcial, sin gracia
    [Required]
    public double SaldoInicial;
    public double Interes;
    public double Amortización;
    public double MontoCuota;
    [Required]
    public double SaldoFinal;
    public double Comision;
    public double SeguroDesgravamen;
    public double SeguroVehicular;
    [Required]
    public double FlujoDeCaja;
    
    [Required]
    public int CreditoId;
}