using Microsoft.AspNetCore.Mvc;

namespace CalculadoraJuros.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class ShowMeTheCodeController : ApiController
    {
        private const string URLPROJETOGIT =  @"https://github.com/GuilhermeVilatoro/SOFTPLAN_CALCULADORAJUROS";

        /// <summary>
        /// Retorna a url de onde se encontra o fonte do projeto no GitHub
        /// </summary>
        /// <remarks>
        /// Exemplo request:
        ///
        ///     GET /showmethecode 
        ///
        /// </remarks>
        /// <returns>Url do código fonte no GitHub</returns>
        /// <response code="200">Url do código fonte no GitHub</response>
        [HttpGet]
        public IActionResult GetShowMeTheCodeViewModel()
        {
            return Response(URLPROJETOGIT);
        }        
    }
}