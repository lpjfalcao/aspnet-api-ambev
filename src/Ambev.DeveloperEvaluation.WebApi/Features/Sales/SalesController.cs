using Ambev.DeveloperEvaluation.Application.Sales.CreateSale;
using Ambev.DeveloperEvaluation.Application.Sales.DeleteSale;
using Ambev.DeveloperEvaluation.Application.Sales.GetSales;
using Ambev.DeveloperEvaluation.Application.Sales.UpdateSale;
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

        [HttpPost]
        public async Task<IActionResult> CreateSale([FromBody] CreateSaleCommand request, CancellationToken cancellationToken)
        {
            var message = await _mediator.Send(request, cancellationToken);

            return CreatedAtRoute("GetSalesById", new { message.Data.Id }, message.Data);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSale(Guid id, [FromBody] UpdateSaleCommand request, CancellationToken cancellationToken)
        {
            request.Id = id;

            var message = await _mediator.Send(request, cancellationToken);

            return StatusCode(message.StatusCode, message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSale(Guid id, CancellationToken cancellationToken)
        {
            var message = await _mediator.Send(new DeleteSaleCommand(id), cancellationToken);

            return StatusCode(message.StatusCode, message);
        }
    }
}
