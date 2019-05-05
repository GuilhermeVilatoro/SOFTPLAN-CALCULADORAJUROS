using CalculadoraJuros.Application.Services.Interfaces;
using CalculadoraJuros.Application.ViewModels;
using CalculadoraJuros.Domain.Exceptions;
using Microsoft.AspNetCore.Mvc;

namespace CalculadoraJuros.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculaJurosController : ApiController
    {
        private readonly ICalculoJurosService _calculoJurosService;

        public CalculaJurosController(ICalculoJurosService calculoJurosService) : base()
        {
            _calculoJurosService = calculoJurosService;
        }

        /// <summary>
        /// Faz o cálculo de juros compostos em memória, conforme seguinte regra: 
        /// Valor Final = Valor Inicial * (1 + juros) ^ Tempo.
        ///  O juros aplicado será de 1%.
        /// </summary>
        /// <remarks>
        /// Exemplo request:
        ///
        ///     GET /calculajuros?valorinicial=100&amp;meses=5 
        ///
        /// </remarks>
        /// <param name="calculaJurosViemModel">Contem o Valor inicial a ser aplicado juros e a Quantidade de meses a ser aplicado juros</param>        
        /// <returns>O resultado será o valor truncado do cálculo sem arredondamento, formatado com duas casas decimais.</returns>
        /// <response code="200">O resultado será o valor truncado do cálculo sem arredondamento, formatado com duas casas decimais</response>
        [HttpPost]
        public IActionResult PostCalculaJurosViewModel(CalculaJurosViewModel calculaJurosViemModel)
        {
            if (!ModelState.IsValid)
                return Response(calculaJurosViemModel);

            try
            {
                var retorno = _calculoJurosService.Calcular(calculaJurosViemModel);
                return Response(retorno.ToString("N2"));
            }
            catch (BusinessException ex)
            {
                return new ObjectResult($"Erro ao calcular juros: {ex.Message}");
            }
        }
    }
}