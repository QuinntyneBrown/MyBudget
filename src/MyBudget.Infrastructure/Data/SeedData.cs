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
                new CostCenter("Footlocker", CostCenterCategory.Clothing,false),
                new CostCenter("LCBO", CostCenterCategory.Recreational,false),
                new CostCenter("Shoppers Drug Mart", CostCenterCategory.Groceries,true),                
                new CostCenter("Loblaws", CostCenterCategory.Groceries,true)
            })
            {
                context.CostCenters.Add(costCenter);
            }

            context.SaveChanges();
        }
    }
}
