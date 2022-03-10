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

    public class UpdateCostCenterValidator: AbstractValidator<UpdateCostCenterRequest>
    {
        public UpdateCostCenterValidator()
        {
            RuleFor(request => request.CostCenter).NotNull();
            RuleFor(request => request.CostCenter).SetValidator(new CostCenterValidator());
        }
    
    }
    public class UpdateCostCenterRequest: IRequest<UpdateCostCenterResponse>
    {
        public CostCenterDto CostCenter { get; set; }
    }
    public class UpdateCostCenterResponse: ResponseBase
    {
        public CostCenterDto CostCenter { get; set; }
    }
    public class UpdateCostCenterHandler: IRequestHandler<UpdateCostCenterRequest, UpdateCostCenterResponse>
    {
        private readonly IMyBudgetDbContext _context;
        private readonly ILogger<UpdateCostCenterHandler> _logger;
    
        public UpdateCostCenterHandler(IMyBudgetDbContext context, ILogger<UpdateCostCenterHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<UpdateCostCenterResponse> Handle(UpdateCostCenterRequest request, CancellationToken cancellationToken)
        {
            var costCenter = await _context.CostCenters.SingleAsync(x => x.CostCenterId == new CostCenterId(request.CostCenter.CostCenterId.Value));
            
            costCenter.Name = request.CostCenter.Name;
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                CostCenter = costCenter.ToDto()
            };
        }
        
    }

}
