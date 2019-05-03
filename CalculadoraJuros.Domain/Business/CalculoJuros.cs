using CalculadoraJuros.Domain.Business.Dto;
using CalculadoraJuros.Domain.Business.Interfaces;
using System;

namespace CalculadoraJuros.Domain.Business
{
    public sealed class CalculoJuros : ICalculoJuros
    {
        public decimal Calcular(InformacoesCalculoJuros informacoesCalculoJuros)
        {
            if (informacoesCalculoJuros == null)
                throw new ArgumentNullException(nameof(informacoesCalculoJuros));

            var valorComJuros = informacoesCalculoJuros.ValorInicial *
                Convert.ToDecimal(Math.Pow(informacoesCalculoJuros.TaxaJuros, informacoesCalculoJuros.TempoEmMeses));

            return Convert.ToDecimal(valorComJuros.ToString("N2"));
        }
    }
}