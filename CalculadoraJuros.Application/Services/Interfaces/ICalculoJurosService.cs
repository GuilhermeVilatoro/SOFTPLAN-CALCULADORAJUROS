using CalculadoraJuros.Application.ViewModels;

namespace CalculadoraJuros.Application.Services.Interfaces
{
    public interface ICalculoJurosService
    {
        /// <summary>
        /// Responsável por realizar o cálculo de juros composto da API.
        /// </summary>
        /// <param name="calculaJurosViewModel">Dados de entrada do webservice via API</param>
        /// <returns>Retorna o cálculo do valor com juros composto embutido</returns>
        decimal Calcular(CalculaJurosViewModel calculaJurosViewModel);
    }
}