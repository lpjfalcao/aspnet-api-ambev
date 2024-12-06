using Ambev.DeveloperEvaluation.Application.Sales.GetSales;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Sales
{
    [Route("api/[controller]")]
    [ApiController]
    public class SalesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SalesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetSales(CancellationToken cancellationToken)
        {
            var message = await _mediator.Send(new GetSalesQuery(), cancellationToken);

            return StatusCode(message.StatusCode, message);
        }

        [HttpGet("{id}", Name = "GetSalesById")]
        public async Task<IActionResult> GetSaleById(Guid id, CancellationToken cancellationToken)
        {
            var message = await _mediator.Send(new GetSaleByIdQuery(id), cancellationToken);

            return StatusCode(message.StatusCode, message);
        }
    }
}
