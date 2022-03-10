using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging;
using MyBudget.Core;
using MyBudget.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyBudget.Core
{

    public class GetCostCentersRequest: IRequest<GetCostCentersResponse> { }
    public class GetCostCentersResponse: ResponseBase
    {
        public List<CostCenterDto> CostCenters { get; set; }
    }
    public class GetCostCentersHandler: IRequestHandler<GetCostCentersRequest, GetCostCentersResponse>
    {
        private readonly IMyBudgetDbContext _context;
        private readonly ILogger<GetCostCentersHandler> _logger;
    
        public GetCostCentersHandler(IMyBudgetDbContext context, ILogger<GetCostCentersHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetCostCentersResponse> Handle(GetCostCentersRequest request, CancellationToken cancellationToken)
        {
            return new () {
                CostCenters = await _context.CostCenters.AsNoTracking().ToDtosAsync(cancellationToken)
            };
        }
        
    }

}
