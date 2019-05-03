namespace CalculadoraJuros.Domain.Business.Dto
{
    public class InformacoesCalculoJuros
    {
        public InformacoesCalculoJuros()
        {
            TaxaJuros = 1.01;
        }

        public decimal ValorInicial { get; set; }

        public int TempoEmMeses { get; set; }

        public double TaxaJuros { get; private set; }
    }
}