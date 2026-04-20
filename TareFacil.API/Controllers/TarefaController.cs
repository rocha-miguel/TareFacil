
using Microsoft.AspNetCore.Mvc;
using TareFacil.API.Models.Requests;
using TareFacil.Application.Services;

namespace TareFacil.API.Controllers {
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase {

        private readonly TarefaService _tarefaService;

        public TarefaController(TarefaService tarefaService) {

            _tarefaService = tarefaService;
        }

        [HttpPost]
        public async Task<IActionResult> Criar([FromBody] CriarTarefaRequest request) {

            try {

                var response = await _tarefaService.CriarAsync(request);

                return StatusCode(201, response);

            } catch (ApplicationException e) {

                return BadRequest(new { mensagem = e.Message });
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(Guid id, [FromBody] AtualizarTarefaRequest request) {

            try {

                var response = await _tarefaService.AtualizarAsync(id, request);

                return Ok(response);

            } catch (ApplicationException e) {

                return BadRequest(new { mensagem = e.Message });
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(Guid id) {

            try {

                await _tarefaService.DeletarAsync(id);

                return NoContent();

            } catch (ApplicationException e) {

                return NotFound(new { mensagem = e.Message });

            }
        }

        [HttpGet]
        public async Task<IActionResult> Listar() {

            try {

                var tarefas = await _tarefaService.ListarAsync();

                return Ok(tarefas);

            } catch (ApplicationException e) {

                return BadRequest(new { mensagem = e.Message });

            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> ListarPorId(Guid id) {

            try {

                var tarefa = await _tarefaService.ListarPorIdAsync(id);

                return Ok(tarefa);

            } catch (ApplicationException e) {

                return NotFound(new { mensagem = e.Message });

            }
        }
    }

}
