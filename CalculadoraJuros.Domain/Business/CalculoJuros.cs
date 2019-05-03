using CalculadoraJuros.Domain.Business.Dto;
using CalculadoraJuros.Domain.Business.Interfaces;
using CalculadoraJuros.Domain.Exceptions;
using CalculadoraJuros.Domain.Extensions;
using System;

namespace CalculadoraJuros.Domain.Business
{
    public sealed class CalculoJuros : ICalculoJuros
    {
        public decimal Calcular(InformacoesCalculoJuros informacoesCalculoJuros)
        {
            if (informacoesCalculoJuros == null)
                throw new ArgumentNullException(nameof(informacoesCalculoJuros));

            if (informacoesCalculoJuros.TempoEmMeses < 0)
                throw new BusinessException("O tempo em meses não pode ser negativo!");          

            //Não foi usado a Math.Pow devido a precisão ser menor que a da extension MathPow criada. 
            var potencia = informacoesCalculoJuros.TaxaJuros.MathPow(informacoesCalculoJuros.TempoEmMeses);           

            var valorComJuros = informacoesCalculoJuros.ValorInicial * potencia;
            
            return Math.Truncate(valorComJuros * 100) / 100;
        }
    }
}