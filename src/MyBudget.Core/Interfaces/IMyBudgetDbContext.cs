using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using System.Threading;

namespace MyBudget.Core.Interfaces
{
    public interface IMyBudgetDbContext
    {
        DbSet<CostCenter> CostCenters { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
        
    }
}
