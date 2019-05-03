using Microsoft.AspNetCore.Mvc;

namespace Livraria.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]    
    public class ShowMeTheCodeController : ApiController
    {
        private const string URLPROJETOGIT =  @"https://github.com/GuilhermeVilatoro/SOFTPLAN_CALCULADORAJUROS";

        // GET: api/ShowMeTheCode
        [HttpGet]
        public IActionResult GetShowMeTheCodeViewModel()
        {
            return Response(URLPROJETOGIT);
        }        
    }
}