using Ambev.DeveloperEvaluation.Common.Helpers;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Services;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Orders.GetOrders
{
    public class GetOrderByIdHandler : IRequestHandler<GetOrderByIdQuery, MessageHelper<GetOrdersResult>>
    {
        private readonly IServiceBase<Order> _serviceBase;
        private readonly IMapper _mapper;

        public GetOrderByIdHandler(IServiceBase<Order> serviceBase, IMapper mapper)
        {
            _serviceBase = serviceBase;
            _mapper = mapper;
        }

        public async Task<MessageHelper<GetOrdersResult>> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            var message = new MessageHelper<GetOrdersResult>();

            try
            {
                if (request.Id is null)
                {
                    throw new DomainException("O Id da venda é um campo obrigatório");
                }

                var sale = _mapper.Map<GetOrdersResult>(await _serviceBase.GetByCondition(x => x.Id == request.Id,
                                                                                         x => x.Customer,
                                                                                         x => x.OrderItems));

                if (sale is null)
                {
                    message.NotFound($"A venda de id {request.Id} não foi encontrada");

                    return message;
                }

                message.Ok(sale);
            }
            catch (DomainException ex)
            {
                message.BadRequest(ex);
            }
            catch (Exception ex)
            {
                message.Error(ex);
            }

            return message;
        }
    }
}
