namespace BackEnd.API.Credit.Domain.Models;

public class Cuota
{
    public int Id { get; set; }
    public int NCuota { get; set; }
    public int TipoPeriodoGracia { get; set; } // Total, parcial, sin gracia
    public double SaldoInicial { get; set; }
    public double Interes { get; set; }
    public double Amortización { get; set; }
    public double MontoCuota { get; set; }
    public double SaldoFinal { get; set; }
    public double Comision { get; set; }
    public double SeguroDesgravamen { get; set; }
    public double SeguroVehicular { get; set; }
    public double FlujoDeCaja { get; set; }
    public int CreditoId { get; set; }
    public Credito Credito { get; set; }
    

}