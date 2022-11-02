using E_Auction.Application.Interfaces;
using E_Auction.Domain.Interfaces.Cosmos;
using E_Auction.Application.DTOs.Cosmos;
using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace E_Auction.Application.Commands.Cosmos
{
    public sealed class GetBidListQuery : IQuery<CloudBidsDto>
    {
        public int ProductId { get; set; }

        internal sealed class GetListQueryHandler : IQueryHandler<GetBidListQuery, CloudBidsDto>
        {
            private readonly IServiceProvider _serviceCollection;
            private readonly IMapper _mapper;
            public GetListQueryHandler(IServiceProvider serviceCollection, IMapper mapper)
            {
                _serviceCollection = serviceCollection;
                _mapper = mapper;
            }

            public async Task<CloudBidsDto> Handle(GetBidListQuery query)
            {
                using (var scope = _serviceCollection.CreateScope())
                {
                    var sellerRepository = scope.ServiceProvider.GetRequiredService<ISellerRepository>();
                    var product =await sellerRepository.GetBidsWithProductById(query.ProductId);
                    //var result = sellerRepository.GetMessage<dynamic>();
                    return _mapper.Map<CloudBidsDto>(product);
                }
            }
        }
    }
}
