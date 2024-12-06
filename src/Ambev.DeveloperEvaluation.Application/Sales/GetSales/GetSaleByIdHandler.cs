using Ambev.DeveloperEvaluation.Common.Helpers;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Services;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales
{
    public class GetSaleByIdHandler : IRequestHandler<GetSaleByIdQuery, MessageHelper<GetSalesResult>>
    {
        private readonly IServiceBase<Sale> _serviceBase;
        private readonly IMapper _mapper;

        public GetSaleByIdHandler(IServiceBase<Sale> serviceBase, IMapper mapper)
        {
            _serviceBase = serviceBase;
            _mapper = mapper;
        }

        public async Task<MessageHelper<GetSalesResult>> Handle(GetSaleByIdQuery request, CancellationToken cancellationToken)
        {
            var message = new MessageHelper<GetSalesResult>();

            try
            {
                if (request.Id is null)
                {
                    throw new DomainException("O Id da venda é um campo obrigatório");
                }
                
                var sale = _mapper.Map<GetSalesResult>(await _serviceBase.GetByCondition(x => x.Id == request.Id));

                if (sale is null)
                {
                    message.NotFound($"A venda de id {request.Id} não foi encontrada");

                    return message;
                }

                message.Ok(sale);
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
