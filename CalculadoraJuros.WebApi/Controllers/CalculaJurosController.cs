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

        // POST: api/CalculaJuros
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