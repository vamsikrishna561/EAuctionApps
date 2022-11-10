using AutoMapper;
using E_Auction.Application.DTOs.Cosmos;
using E_Auction.Application.Interfaces;
using E_Auction.Domain.Interfaces.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace E_Auction.Application.Commands.Cosmos
{
    public sealed class GetProductListBySellerQuery : IQuery<List<CloudProductDto>>
    {
        public string SellerId { get; set; }
        public sealed class GetProductListBySellerHandler : IQueryHandler<GetProductListBySellerQuery, List<CloudProductDto>>
        {
            private readonly IServiceProvider _serviceCollection;
            private readonly IMapper _mapper;

            public GetProductListBySellerHandler(IServiceProvider serviceCollection, IMapper mapper)
            {
                _serviceCollection = serviceCollection;
                _mapper = mapper;
            }

            public async Task<List<CloudProductDto>> Handle(GetProductListBySellerQuery getProductListQuery)
            {
                using (var scope = _serviceCollection.CreateScope())
                {
                    var sellerRepository = scope.ServiceProvider.GetRequiredService<ISellerRepository>();
                    var seller = sellerRepository.GetSellerByEmailId(getProductListQuery.SellerId);
                    var products = await sellerRepository.GetProducts();
                    products.FindAll(x => seller.ProductIds.Any(y => y == x.Id));
                    //var result = sellerRepository.GetMessage<dynamic>();
                    return _mapper.Map<List<CloudProductDto>>(products);
                }
            }
        }
    }
}
