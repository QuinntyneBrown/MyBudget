using Microsoft.EntityFrameworkCore;

namespace MyBudget.Core
{
    public static class CostCenterExtensions
    {
        public static CostCenterDto ToDto(this CostCenter costCenter)
        {
            return new ()
            {
                CostCenterId = costCenter.CostCenterId.Value,
                Name = costCenter.Name,
                Category = costCenter.Category,
                IsEssential = costCenter.IsEssential,
            };
        }
        
        public static async Task<List<CostCenterDto>> ToDtosAsync(this IQueryable<CostCenter> costCenters, CancellationToken cancellationToken)
        {
            return await costCenters.Select(x => x.ToDto()).ToListAsync(cancellationToken);
        }
        
        public static List<CostCenterDto> ToDtos(this IEnumerable<CostCenter> costCenters)
        {
            return costCenters.Select(x => x.ToDto()).ToList();
        }
        
    }
}
