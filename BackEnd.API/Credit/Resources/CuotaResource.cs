namespace BackEnd.API.Credit.Resources;

public class CuotaResource
{
    public int Id;
    public int NCuota;
    public int TipoPeriodoGracia; // Total, parcial, sin gracia
    public double SaldoInicial;
    public double Interes;
    public double Amortización;
    public double MontoCuota;
    public double SaldoFinal;
    public double Comision;
    public double SeguroDesgravamen;
    public double SeguroVehicular;
    public double FlujoDeCaja;
    public CreditoResource Credito;
}