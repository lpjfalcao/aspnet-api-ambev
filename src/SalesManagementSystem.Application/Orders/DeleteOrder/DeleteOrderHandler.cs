using SalesManagementSystem.Common.Helpers;
using SalesManagementSystem.Domain.Entities;
using SalesManagementSystem.Domain.Interfaces.Services;
using AutoMapper;
using MediatR;

namespace SalesManagementSystem.Application.Orders.DeleteOrder
{
    public class DeleteOrderHandler : IRequestHandler<DeleteOrderCommand, MessageHelper>
    {
        private readonly IServiceBase<Order> _serviceBase;
        private readonly IMapper _mapper;

        public DeleteOrderHandler(IServiceBase<Order> serviceBase, IMapper mapper)
        {
            _serviceBase = serviceBase;
            _mapper = mapper;
        }
        public async Task<MessageHelper> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            var message = new MessageHelper();

            try
            {
                var sale = await _serviceBase.GetByCondition(x => x.Id == request.Id) ??
                    throw new DomainException($"A venda de id {request.Id} não existe no sistema");

                _serviceBase.Remove(sale);

                await _serviceBase.Commit();

                message.Ok();
            }
            catch(DomainException ex)
            {
                message.BadRequest(ex);
            }
            catch(Exception ex)
            {
                message.Error(ex);
            }

            return message;
        }
    }
}
