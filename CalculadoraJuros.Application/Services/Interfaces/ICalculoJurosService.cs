using CalculadoraJuros.Application.ViewModels;

namespace CalculadoraJuros.Application.Services.Interfaces
{
    public interface ICalculoJurosService
    {
        decimal Calcular(CalculaJurosViewModel calculaJurosViewModel);
    }
}