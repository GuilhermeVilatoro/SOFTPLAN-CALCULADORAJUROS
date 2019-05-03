using CalculadoraJuros.Application.Services.Interfaces;
using CalculadoraJuros.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Livraria.WebApi.Controllers
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

            var retorno = _calculoJurosService.Calcular(calculaJurosViemModel);

            return Response(retorno.ToString());
        }
    }
}