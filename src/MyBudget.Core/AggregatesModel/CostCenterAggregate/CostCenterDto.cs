using System;

namespace MyBudget.Core
{
    public class CostCenterDto
    {
        public Guid? CostCenterId { get; set; }
        public string Name { get; set; }
        public CostCenterCategory Category { get; set; }
        public bool IsEssential { get; set; }
    }
}
