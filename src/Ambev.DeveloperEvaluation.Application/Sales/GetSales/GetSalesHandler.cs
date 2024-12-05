using Ambev.DeveloperEvaluation.Common.Helpers;
using Ambev.DeveloperEvaluation.Domain.Entities;
using Ambev.DeveloperEvaluation.Domain.Services;
using AutoMapper;
using MediatR;

namespace Ambev.DeveloperEvaluation.Application.Sales.GetSales
{
    public class GetSalesHandler : IRequestHandler<GetSalesCommand, MessageHelper<IEnumerable<GetSalesResult>>>
    {
        private readonly IServiceBase<Sale> _serviceBase;
        private readonly IMapper _mapper;

        public GetSalesHandler(IServiceBase<Sale> serviceBase, IMapper mapper)
        {
            _serviceBase = serviceBase;
            _mapper = mapper;
        }

        public async Task<MessageHelper<IEnumerable<GetSalesResult>>> Handle(GetSalesCommand request, CancellationToken cancellationToken)
        {
            var message = new MessageHelper<IEnumerable<GetSalesResult>>();

            try
            {
                var sales = _mapper.Map<IEnumerable<GetSalesResult>>(await _serviceBase.GetAll());

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
