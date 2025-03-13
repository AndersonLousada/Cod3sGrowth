using Cod3rsGrowth.DOMINIO.Carros;
using Microsoft.AspNetCore.Mvc;

namespace Cod3rsGrowth.WEB.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarroController : ControllerBase
    {
        private readonly ServicoCarro _servicoCarro;

        public CarroController(ServicoCarro carro)
        {
            _servicoCarro = carro;
        }

        [HttpPost]
        public CreatedResult Criar([FromBody] Carro carro)
        {
            _servicoCarro.Criar(carro);
            return Created(carro.Id.ToString()!, carro);
        }

        [HttpGet]
        public IActionResult ObterTodos([FromQuery] Filtro filtro)
        {
            var carros = _servicoCarro.ObterTodos(filtro);

            return Ok(carros);
        }

        [HttpGet]
        [Route("{id}")]
        public IActionResult ObterPorId([FromRoute] int id)
        {
            var carro = _servicoCarro.ObterPorId(id);

            return Ok(carro);
        }

        [HttpPatch]
        [Route("{id}")]
        public NoContentResult Atualizar([FromRoute] int id, [FromBody] Carro carro)
        {
            carro.Id = id;
            _servicoCarro.Atualizar(carro);

            return NoContent();
        }
    }
}