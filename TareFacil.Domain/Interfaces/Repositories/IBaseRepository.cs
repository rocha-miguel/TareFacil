namespace TareFacil.Domain.Interfaces.Repositories {
    public interface IBaseRepository<T> where T : class {

        Task CriarAsync(T obj);

        Task AtualizarAsync(T obj);

        Task DeletarAsync(T obj);

        Task<List<T>> ListarTudoAsync();

        Task<T?> ListarPorIdAsync(Guid id);

    }
}
