

using TareFacil.API.Models.Requests;
using TareFacil.API.Models.Responses;
using TareFacil.Domain.Entities;
using TareFacil.Domain.Interfaces.Repositories;

namespace TareFacil.Application.Services {
    public class TarefaService {

        private readonly IBaseRepository<Tarefa> _tarefaRepository;

        public TarefaService(IBaseRepository<Tarefa> tarefaRepository) {

            _tarefaRepository = tarefaRepository;
        }

        public async Task<DadosTarefaResponse> CriarAsync(CriarTarefaRequest request) {

            var tarefa = new Tarefa {

                Titulo = request.Titulo!,
                Descricao = request.Descricao!,

            };

            await _tarefaRepository.CriarAsync(tarefa);

            return new DadosTarefaResponse {

                Mensagem = "Tarefa criada com sucesso!",
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                DataCriacao = tarefa.DataCriacao,
                DataConclusao = tarefa.DataConclusao,
                Status = tarefa.Status
            };
        }

        public async Task<DadosTarefaResponse> AtualizarAsync(Guid id, AtualizarTarefaRequest request) {

            var tarefa = await _tarefaRepository.ListarPorIdAsync(id);

            if (tarefa == null)
                throw new ApplicationException("Tarefa não encontrada.");

            tarefa.Titulo = request.Titulo!;
            tarefa.Descricao = request.Descricao!;
            tarefa.DefinirConclusao(request.DataConclusao);
            tarefa.Status = request.Status;

            await _tarefaRepository.AtualizarAsync(tarefa);

            return new DadosTarefaResponse {

                Mensagem = "Tarefa atualizada com sucesso!",
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                DataCriacao = tarefa.DataCriacao,
                DataConclusao = tarefa.DataConclusao,
                Status = tarefa.Status
            };

        }

        public async Task DeletarAsync(Guid id) {

            var tarefa = await _tarefaRepository.ListarPorIdAsync(id);

            if (tarefa == null)
                throw new ApplicationException("Tarefa não encontrada.");

            await _tarefaRepository.DeletarAsync(tarefa);
        }

        public async Task<DadosTarefaResponse> ListarPorIdAsync(Guid id) {

            var tarefa = await _tarefaRepository.ListarPorIdAsync(id);

            if (tarefa == null)
                throw new ApplicationException("Tarefa não encontrada.");

            return new DadosTarefaResponse {

                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                DataCriacao = tarefa.DataCriacao,
                DataConclusao = tarefa.DataConclusao,
                Status = tarefa.Status

            };
        }

        public async Task<List<DadosTarefaResponse>> ListarAsync() {

            var tarefas = await _tarefaRepository.ListarTudoAsync();

            return tarefas.Select(tarefa => new DadosTarefaResponse {
                Id = tarefa.Id,
                Titulo = tarefa.Titulo,
                Descricao = tarefa.Descricao,
                DataCriacao = tarefa.DataCriacao,
                DataConclusao = tarefa.DataConclusao,
                Status = tarefa.Status
            }).ToList()!;
        }
    }
}
