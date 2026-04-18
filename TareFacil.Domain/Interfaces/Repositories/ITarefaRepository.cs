namespace TareFacil.Domain.Interfaces.Repositories {
    public interface ITarefaRepository<T> where T : class {

        void Criar(T obj);

        void Atualizar(T obj);

        void Deletar(Guid id);

        List<T> ListarTudo();

        T? ListarPorId(Guid id);

    }
}
