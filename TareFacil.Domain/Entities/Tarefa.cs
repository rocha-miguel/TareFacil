

using TareFacil.Domain.Enums;

namespace TareFacil.Domain.Entities {
    public class Tarefa {

        public Guid Id { get; set; } = Guid.NewGuid();

        public string Titulo { get; set; } = string.Empty;

        public string Descricao { get; set; } = string.Empty;

        public DateTime DataCriacao { get; set; } = DateTime.Now;

        public DateTime? DataConclusao { get; set; }

        public StatusTarefa Status { get; set; } = StatusTarefa.Pendente;

        public void DefinirConclusao(DateTime? dataConclusao) {

            if (dataConclusao.HasValue && dataConclusao.Value < DataCriacao) {
                throw new ApplicationException("A data de conclusão não pode ser anterior à data de criação.");
            }

            DataConclusao = dataConclusao;
        }
    }
}
