namespace BackEnd.API.Credit.Resources;

public class CuotaResource
{
    public int Id { get; set; }
    public int NCuota { get; set; }
    public string Fecha { get; set; }
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
    public CreditoResource Credito { get; set; }
}