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

    public class GetCostCenterByIdRequest: IRequest<GetCostCenterByIdResponse>
    {
        public Guid CostCenterId { get; set; }
    }
    public class GetCostCenterByIdResponse: ResponseBase
    {
        public CostCenterDto CostCenter { get; set; }
    }
    public class GetCostCenterByIdHandler: IRequestHandler<GetCostCenterByIdRequest, GetCostCenterByIdResponse>
    {
        private readonly IMyBudgetDbContext _context;
        private readonly ILogger<GetCostCenterByIdHandler> _logger;
    
        public GetCostCenterByIdHandler(IMyBudgetDbContext context, ILogger<GetCostCenterByIdHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetCostCenterByIdResponse> Handle(GetCostCenterByIdRequest request, CancellationToken cancellationToken)
        {
            return new () {
                CostCenter = (await _context.CostCenters.AsNoTracking().SingleOrDefaultAsync(x => x.CostCenterId == new CostCenterId(request.CostCenterId))).ToDto()
            };
        }
        
    }

}
