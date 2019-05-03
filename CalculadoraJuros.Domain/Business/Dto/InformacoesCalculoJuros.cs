namespace CalculadoraJuros.Domain.Business.Dto
{
    public class InformacoesCalculoJuros
    {
        public InformacoesCalculoJuros()
        {
            TaxaJuros = 1.01M;
        }

        public decimal ValorInicial { get; set; }

        public int TempoEmMeses { get; set; }

        public decimal TaxaJuros { get; private set; }
    }
}