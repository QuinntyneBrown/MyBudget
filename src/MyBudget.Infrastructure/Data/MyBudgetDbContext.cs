using MyBudget.Core;
using MyBudget.Core.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Linq;

namespace MyBudget.Infrastructure.Data
{
    public class MyBudgetDbContext: DbContext, IMyBudgetDbContext
    {
        public DbSet<CostCenter> CostCenters { get; private set; }
        public MyBudgetDbContext(DbContextOptions options)
            :base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(MyBudgetDbContext).Assembly);
        }
        
    }
}
