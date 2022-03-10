using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyBudget.Core;
using MyBudget.Core.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyBudget.Core
{

    public class RemoveCostCenterRequest: IRequest<RemoveCostCenterResponse>
    {
        public Guid CostCenterId { get; set; }
    }
    public class RemoveCostCenterResponse: ResponseBase
    {
        public CostCenterDto CostCenter { get; set; }
    }
    public class RemoveCostCenterHandler: IRequestHandler<RemoveCostCenterRequest, RemoveCostCenterResponse>
    {
        private readonly IMyBudgetDbContext _context;
        private readonly ILogger<RemoveCostCenterHandler> _logger;
    
        public RemoveCostCenterHandler(IMyBudgetDbContext context, ILogger<RemoveCostCenterHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<RemoveCostCenterResponse> Handle(RemoveCostCenterRequest request, CancellationToken cancellationToken)
        {
            var costCenter = await _context.CostCenters.FindAsync(new CostCenterId(request.CostCenterId));
            
            _context.CostCenters.Remove(costCenter);
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                CostCenter = costCenter.ToDto()
            };
        }
        
    }

}
