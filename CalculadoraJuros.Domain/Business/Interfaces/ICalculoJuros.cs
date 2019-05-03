using CalculadoraJuros.Domain.Business.Dto;

namespace CalculadoraJuros.Domain.Business.Interfaces
{
    public interface ICalculoJuros
    {
        /// <summary>
        /// Responsável por realizar o cálculo em memória, de juros compostos.
        /// </summary>
        /// <param name="informacoesCalculoJuros">Informações necessárias para realizar o cáclulo de juros composto</param>
        /// <returns>Retorna o valor final acrescido de juros, com precisão de duas casas decimais</returns>
        decimal Calcular(InformacoesCalculoJuros informacoesCalculoJuros);
    }
}