
using Microsoft.EntityFrameworkCore;
using TareFacil.Domain.Entities;
using TareFacil.Domain.Interfaces.Repositories;
using TareFacil.Infra.Data.Contexts;

namespace TareFacil.Infra.Data.Repositories {
    public class TarefaRepository : IBaseRepository<Tarefa> {

        private readonly DataContext _dataContext;

        public TarefaRepository(DataContext dataContext) {
            _dataContext = dataContext;
        }
        public async Task AtualizarAsync(Tarefa obj) {

            _dataContext.Update(obj);
            await _dataContext.SaveChangesAsync();

        }

        public async Task CriarAsync(Tarefa obj) {

            await _dataContext.AddAsync(obj);
            await _dataContext.SaveChangesAsync();

        }

        public async Task DeletarAsync(Tarefa obj) {

            _dataContext.Remove(obj);
            await _dataContext.SaveChangesAsync();

        }

        public async Task<Tarefa?> ListarPorIdAsync(Guid id) {

            return await _dataContext
                .Set<Tarefa>()
                .FirstOrDefaultAsync(t => t.Id == id);
        }

        public async Task<List<Tarefa>> ListarTudoAsync() {

            return await _dataContext
               .Set<Tarefa>()
               .OrderBy(t => t.Titulo)
               .ToListAsync();

        }
    }
}

