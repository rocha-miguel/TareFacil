using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TareFacil.API.Models.Requests;

namespace TareFacil.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase {

        [HttpPost]
        public IActionResult Criar([FromBody] CriarTarefaRequest request) {

            return Ok();
        }

        [HttpPut("{id}")]
        public IActionResult Atualizar(Guid id, [FromBody] AtualizarTarefaRequest request) {

            return Ok();
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(Guid id) {

            return Ok();
        }

        [HttpGet]
        public IActionResult Listar() {

            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult ListarPorId(Guid id) {

            return Ok();
        }
    }

}
