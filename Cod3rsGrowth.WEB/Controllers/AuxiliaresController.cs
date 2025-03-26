using Cod3rsGrowth.DOMINIO.Carros;
using Cod3rsGrowth.DOMINIO.Extencoes;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuxiliaresController : ControllerBase
    {

        [HttpGet]
        public IActionResult ObterEnumeradores()
        {
            var enumeradores = ExtensaoEnum.GetEnumDescriptions<Combustivel>();
            return Ok(enumeradores);
        }
    }
}