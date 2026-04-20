using TareFacil.Domain.Enums;

namespace TareFacil.API.Models.Responses {
    public class DadosTarefaResponse {

        public string? Mensagem { get; set; }

        public Guid? Id { get; set; }

        public string? Titulo { get; set; }

        public string? Descricao { get; set; }

        public DateTime? DataCriacao { get; set; }

        public DateTime? DataConclusao { get; set; }

        public StatusTarefa Status { get; set; }
    }
}
