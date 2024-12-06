using Ambev.DeveloperEvaluation.Common.Helpers;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Services;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.GetOrders
{
    public class GetOrderHandler : IRequestHandler<GetOrdersQuery, MessageHelper<IEnumerable<GetOrdersResult>>>
    {
        private readonly IServiceBase<Order> _serviceBase;
        private readonly IMapper _mapper;

        public GetOrderHandler(IServiceBase<Order> serviceBase, IMapper mapper)
        {
            _serviceBase = serviceBase;
            _mapper = mapper;
        }

        public async Task<MessageHelper<IEnumerable<GetOrdersResult>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var message = new MessageHelper<IEnumerable<GetOrdersResult>>();

            try
            {
                var sales = _mapper.Map<IEnumerable<GetOrdersResult>>(await _serviceBase.GetAll(x => x.Customer,
                                                                                               x => x.OrderItems));

                if (!sales.Any())
                {
                    message.NotFound("Nenhuma venda encontrada");

                    return message;
                }

                message.Ok(sales);
            }
            catch (Exception ex)
            {
                message.Error(ex);
            }

            return message;
        }
    }
}
