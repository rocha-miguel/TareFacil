

using Microsoft.EntityFrameworkCore;
using TareFacil.Infra.Data.Mappings;

namespace TareFacil.Infra.Data.Contexts {
    public class DataContext : DbContext {

        public DataContext(DbContextOptions<DataContext> context) : base(context) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            modelBuilder.ApplyConfiguration(new TarefaMap());
        }
    }
}
