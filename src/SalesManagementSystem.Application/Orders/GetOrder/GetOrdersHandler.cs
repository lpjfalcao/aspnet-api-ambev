using SalesManagementSystem.Common.Helpers;
using SalesManagementSystem.Domain.Entities;
using SalesManagementSystem.Domain.Interfaces.Services;
using AutoMapper;
using MediatR;

namespace SalesManagementSystem.Application.Orders.GetOrders
{
    public class GetOrdersHandler : IRequestHandler<GetOrdersQuery, MessageHelper<IEnumerable<GetOrdersResult>>>
    {
        private readonly IServiceBase<Order> _serviceBase;
        private readonly IMapper _mapper;

        public GetOrdersHandler(IServiceBase<Order> serviceBase, IMapper mapper)
        {
            _serviceBase = serviceBase;
            _mapper = mapper;
        }

        public async Task<MessageHelper<IEnumerable<GetOrdersResult>>> Handle(GetOrdersQuery request, CancellationToken cancellationToken)
        {
            var message = new MessageHelper<IEnumerable<GetOrdersResult>>();

            try
            {
                var orders = await _serviceBase.GetAll(x => x.Customer, x => x.OrderItems, x => x.Branch);

                if (!orders.Any())
                {
                    message.NotFound("Nenhuma venda encontrada");

                    return message;
                }

                message.Ok(_mapper.Map<IEnumerable<GetOrdersResult>>(orders));
            }
            catch (Exception ex)
            {
                message.Error(ex);
            }

            return message;
        }
    }
}
