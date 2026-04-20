using System.ComponentModel.DataAnnotations;

namespace TareFacil.API.Models.Requests {
    public class CriarTarefaRequest {

        [MaxLength(100, ErrorMessage = "O título da tarefa deve ter no máximo 100 caracteres.")]
        [Required(ErrorMessage = "Por favor, informe um título para a tarefa.")]
        public string? Titulo { get; set; }

        [Required(ErrorMessage = "Por favor, informe uma descrição para a tarefa.")]
        public string? Descricao { get; set; }

    }
}
