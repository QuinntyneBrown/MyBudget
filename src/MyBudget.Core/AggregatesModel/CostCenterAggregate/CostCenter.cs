using System;

namespace MyBudget.Core
{
    public class CostCenter
    {
        public CostCenterId CostCenterId { get; set; }  = new CostCenterId(Guid.NewGuid());
        public string Name { get; set; }
    }
}
