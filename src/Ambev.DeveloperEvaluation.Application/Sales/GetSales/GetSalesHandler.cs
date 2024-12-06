using Ambev.DeveloperEvaluation.Common.Helpers;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Interfaces.Services;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales
{
    public class GetSalesHandler : IRequestHandler<GetSalesQuery, MessageHelper<IEnumerable<GetSalesResult>>>
    {
        private readonly IServiceBase<Sale> _serviceBase;
        private readonly IMapper _mapper;

        public GetSalesHandler(IServiceBase<Sale> serviceBase, IMapper mapper)
        {
            _serviceBase = serviceBase;
            _mapper = mapper;
        }

        public async Task<MessageHelper<IEnumerable<GetSalesResult>>> Handle(GetSalesQuery request, CancellationToken cancellationToken)
        {
            var message = new MessageHelper<IEnumerable<GetSalesResult>>();

            try
            {
                var sales = _mapper.Map<IEnumerable<GetSalesResult>>(await _serviceBase.GetAll(x => x.Products));

                if (!sales.Any())
                {
                    message.NotFound("Nenhuma venda encontrada");

                    return message;
                }

                message.Ok(sales);
            }
            catch(Exception ex)
            {
                message.Error(ex);
            }

            return message;
        }
    }
}
