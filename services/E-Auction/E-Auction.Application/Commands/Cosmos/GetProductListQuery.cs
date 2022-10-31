using AutoMapper;
using E_Auction.Application.DTOs.Cosmos;
using E_Auction.Application.Interfaces;
using E_Auction.Domain.Interfaces.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace E_Auction.Application.Commands.Cosmos
{
    public sealed class GetProductListQuery : IQuery<List<ProductDto>>
    {
        public int SellerId { get; set; }
        public sealed class GetProductListQueryHandler : IQueryHandler<GetProductListQuery,List<ProductDto>>
        {
            private readonly IServiceProvider _serviceCollection;
            private readonly IMapper _mapper;

            public GetProductListQueryHandler(IServiceProvider serviceCollection, IMapper mapper)
            {
                _serviceCollection = serviceCollection;
                _mapper = mapper;
            }

            public async Task<List<ProductDto>> Handle(GetProductListQuery getProductListQuery)
            {
                using (var scope = _serviceCollection.CreateScope())
                {
                    var sellerRepository = scope.ServiceProvider.GetRequiredService<ISellerRepository>();
                    var product = await sellerRepository.GetProducts();
                    //var result = sellerRepository.GetMessage<dynamic>();
                    return _mapper.Map<List<ProductDto>>(product);
                }
            }
        }
    }
}
