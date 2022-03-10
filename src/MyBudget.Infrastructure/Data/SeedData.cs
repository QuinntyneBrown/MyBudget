using MyBudget.Core;
using System;

namespace MyBudget.Infrastructure.Data
{
    public static class SeedData
    {
        public static void Seed(MyBudgetDbContext context)
        {
            foreach (var costCenter in new List<CostCenter>()
            {
                new CostCenter() { Name = "Footlocker" },
                new CostCenter() { Name = "Shopper Drug Mart" },
                new CostCenter(){ Name = "Nike Outlet" },
                new CostCenter() { Name = "LCBO" }
            })
            {
                context.CostCenters.Add(costCenter);
            }

            context.SaveChanges();
        }
    }
}
