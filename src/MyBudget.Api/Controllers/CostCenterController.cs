using System.Net;
using System.Threading;
using System.Threading.Tasks;
using MyBudget.Core;
using MediatR;
using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Swashbuckle.AspNetCore.Annotations;
using System.Net.Mime;

namespace MyBudget.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Produces(MediaTypeNames.Application.Json)]
    [Consumes(MediaTypeNames.Application.Json)]
    public class CostCenterController
    {
        private readonly IMediator _mediator;
        private readonly ILogger<CostCenterController> _logger;

        public CostCenterController(IMediator mediator, ILogger<CostCenterController> logger)
        {
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        [SwaggerOperation(
            Summary = "Get CostCenter by id.",
            Description = @"Get CostCenter by id."
        )]
        [HttpGet("{costCenterId:guid}", Name = "getCostCenterById")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.NotFound)]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCostCenterByIdResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCostCenterByIdResponse>> GetById([FromRoute]Guid costCenterId, CancellationToken cancellationToken)
        {
            var request = new GetCostCenterByIdRequest() { CostCenterId = costCenterId };
        
            var response = await _mediator.Send(request, cancellationToken);
        
            if (response.CostCenter == null)
            {
                return new NotFoundObjectResult(request.CostCenterId);
            }
        
            return response;
        }
        
        [SwaggerOperation(
            Summary = "Get CostCenters.",
            Description = @"Get CostCenters."
        )]
        [HttpGet(Name = "getCostCenters")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCostCentersResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCostCentersResponse>> Get(CancellationToken cancellationToken)
        {
            return await _mediator.Send(new GetCostCentersRequest(), cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Create CostCenter.",
            Description = @"Create CostCenter."
        )]
        [HttpPost(Name = "createCostCenter")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(CreateCostCenterResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<CreateCostCenterResponse>> Create([FromBody]CreateCostCenterRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName}: ({@Command})",
                nameof(CreateCostCenterRequest),
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Get CostCenter Page.",
            Description = @"Get CostCenter Page."
        )]
        [HttpGet("page/{pageSize}/{index}", Name = "getCostCentersPage")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(GetCostCentersPageResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<GetCostCentersPageResponse>> Page([FromRoute]int pageSize, [FromRoute]int index, CancellationToken cancellationToken)
        {
            var request = new GetCostCentersPageRequest { Index = index, PageSize = pageSize };
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Update CostCenter.",
            Description = @"Update CostCenter."
        )]
        [HttpPut(Name = "updateCostCenter")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(UpdateCostCenterResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<UpdateCostCenterResponse>> Update([FromBody]UpdateCostCenterRequest request, CancellationToken cancellationToken)
        {
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                nameof(UpdateCostCenterRequest),
                nameof(request.CostCenter.CostCenterId),
                request.CostCenter.CostCenterId,
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
        [SwaggerOperation(
            Summary = "Delete CostCenter.",
            Description = @"Delete CostCenter."
        )]
        [HttpDelete("{costCenterId:guid}", Name = "removeCostCenter")]
        [ProducesResponseType((int)HttpStatusCode.InternalServerError)]
        [ProducesResponseType(typeof(ProblemDetails), (int)HttpStatusCode.BadRequest)]
        [ProducesResponseType(typeof(RemoveCostCenterResponse), (int)HttpStatusCode.OK)]
        public async Task<ActionResult<RemoveCostCenterResponse>> Remove([FromRoute]Guid costCenterId, CancellationToken cancellationToken)
        {
            var request = new RemoveCostCenterRequest() { CostCenterId = costCenterId };
        
            _logger.LogInformation(
                "----- Sending command: {CommandName} - {IdProperty}: {CommandId} ({@Command})",
                nameof(RemoveCostCenterRequest),
                nameof(request.CostCenterId),
                request.CostCenterId,
                request);
        
            return await _mediator.Send(request, cancellationToken);
        }
        
    }
}
