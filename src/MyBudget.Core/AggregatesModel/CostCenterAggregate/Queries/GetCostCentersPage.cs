using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using MyBudget.Core;
using MyBudget.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyBudget.Core
{

    public class GetCostCentersPageRequest: IRequest<GetCostCentersPageResponse>
    {
        public int PageSize { get; set; }
        public int Index { get; set; }
    }
    public class GetCostCentersPageResponse: ResponseBase
    {
        public int Length { get; set; }
        public List<CostCenterDto> Entities { get; set; }
    }
    public class GetCostCentersPageHandler: IRequestHandler<GetCostCentersPageRequest, GetCostCentersPageResponse>
    {
        private readonly IMyBudgetDbContext _context;
        private readonly ILogger<GetCostCentersPageHandler> _logger;
    
        public GetCostCentersPageHandler(IMyBudgetDbContext context, ILogger<GetCostCentersPageHandler> logger)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }
    
        public async Task<GetCostCentersPageResponse> Handle(GetCostCentersPageRequest request, CancellationToken cancellationToken)
        {
            var query = from costCenter in _context.CostCenters
                select costCenter;
            
            var length = await _context.CostCenters.AsNoTracking().CountAsync();
            
            var costCenters = await query.Page(request.Index, request.PageSize).AsNoTracking()
                .Select(x => x.ToDto()).ToListAsync();
            
            return new ()
            {
                Length = length,
                Entities = costCenters
            };
        }
        
    }

}
