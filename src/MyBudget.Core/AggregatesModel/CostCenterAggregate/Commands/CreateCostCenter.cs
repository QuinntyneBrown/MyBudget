using FluentValidation;
using MediatR;
using Microsoft.Extensions.Logging;
using MyBudget.Core;
using MyBudget.Core.Interfaces;
using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyBudget.Core
{

    public class CreateCostCenterValidator: AbstractValidator<CreateCostCenterRequest>
    {
        public CreateCostCenterValidator()
        {
            RuleFor(request => request.CostCenter).NotNull();
            RuleFor(request => request.CostCenter).SetValidator(new CostCenterValidator());
        }
    
    }
    public class CreateCostCenterRequest: IRequest<CreateCostCenterResponse>
    {
        public CostCenterDto CostCenter { get; set; }
    }
    public class CreateCostCenterResponse: ResponseBase
    {
        public CostCenterDto CostCenter { get; set; }
    }
    public class CreateCostCenterHandler: IRequestHandler<CreateCostCenterRequest, CreateCostCenterResponse>
    {
        private readonly IMyBudgetDbContext _context;
        private readonly ILogger<CreateCostCenterHandler> _logger;
    
        public CreateCostCenterHandler(IMyBudgetDbContext context, ILogger<CreateCostCenterHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<CreateCostCenterResponse> Handle(CreateCostCenterRequest request, CancellationToken cancellationToken)
        {
            var costCenter = new CostCenter();
            
            _context.CostCenters.Add(costCenter);
            
            costCenter.Name = request.CostCenter.Name;
            
            await _context.SaveChangesAsync(cancellationToken);
            
            return new ()
            {
                CostCenter = costCenter.ToDto()
            };
        }
        
    }

}
