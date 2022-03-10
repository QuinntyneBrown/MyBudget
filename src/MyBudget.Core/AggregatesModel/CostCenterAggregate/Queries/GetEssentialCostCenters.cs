using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyBudget.Core.Interfaces;

namespace MyBudget.Core
{

    public class GetEssentialCostCentersRequest : IRequest<GetCostCentersResponse> { }
    public class GetEssentialCostCentersResponse : ResponseBase
    {
        public List<CostCenterDto> CostCenters { get; set; }
    }
    public class GetEssentialCostCentersHandler : IRequestHandler<GetCostCentersRequest, GetCostCentersResponse>
    {
        private readonly IMyBudgetDbContext _context;
        private readonly ILogger<GetCostCentersHandler> _logger;
    
        public GetEssentialCostCentersHandler(IMyBudgetDbContext context, ILogger<GetCostCentersHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetCostCentersResponse> Handle(GetCostCentersRequest request, CancellationToken cancellationToken)
        {
            return new () {
                CostCenters = await _context.CostCenters
                .Where(x => x.IsEssential == true)
                .AsNoTracking().ToDtosAsync(cancellationToken)
            };
        }
        
    }

}
