using Ambev.DeveloperEvaluation.Common.Helpers;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Services;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.DeleteSale
{
    public class DeleteSaleHandler : IRequestHandler<DeleteSaleCommand, MessageHelper>
    {
        private readonly IServiceBase<Sale> _serviceBase;
        private readonly IMapper _mapper;

        public DeleteSaleHandler(IServiceBase<Sale> serviceBase, IMapper mapper)
        {
            _serviceBase = serviceBase;
            _mapper = mapper;
        }
        public async Task<MessageHelper> Handle(DeleteSaleCommand request, CancellationToken cancellationToken)
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
