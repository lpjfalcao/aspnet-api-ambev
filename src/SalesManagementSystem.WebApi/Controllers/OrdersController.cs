using SalesManagementSystem.Application.Orders.CreateOrder;
using SalesManagementSystem.Application.Orders.DeleteOrder;
using SalesManagementSystem.Application.Orders.GetOrders;
using SalesManagementSystem.Application.Orders.UpdateOrder;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace SalesManagementSystem.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrders(CancellationToken cancellationToken)
        {
            var message = await _mediator.Send(new GetOrdersQuery(), cancellationToken);

            return StatusCode(message.StatusCode, message);
        }

        [HttpGet("{id}", Name = "GetOrdersById")]
        public async Task<IActionResult> GetOrderById(Guid id, CancellationToken cancellationToken)
        {
            var message = await _mediator.Send(new GetOrderByIdQuery(id), cancellationToken);

            return StatusCode(message.StatusCode, message);
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var message = await _mediator.Send(request, cancellationToken);

            return message.Success
                ? CreatedAtRoute("GetOrdersById", new { message.Data.Id }, message.Data)
                : StatusCode(message.StatusCode, message);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(Guid id, [FromBody] UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            request.Id = id;

            var message = await _mediator.Send(request, cancellationToken);

            return StatusCode(message.StatusCode, message);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteOrder(Guid id, CancellationToken cancellationToken)
        {
            var message = await _mediator.Send(new DeleteOrderCommand(id), cancellationToken);

            return StatusCode(message.StatusCode, message);
        }
    }
}
