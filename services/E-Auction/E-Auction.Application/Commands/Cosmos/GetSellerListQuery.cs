using AutoMapper;
using CSharpFunctionalExtensions;
using E_Auction.Application.DTOs.Cosmos;
using E_Auction.Application.Interfaces;
using E_Auction.Domain.Interfaces.Cosmos;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Application.Commands.Cosmos
{
    public sealed class GetSellerListQuery : IQuery<List<CloudSellerDto>>
    {
        public int SellerId { get; set; }
        public sealed class GetSellerListQueryHandler : IQueryHandler<GetSellerListQuery, List<CloudSellerDto>>
        {
            private readonly IServiceProvider _serviceCollection;
            private readonly IMapper _mapper;

            public GetSellerListQueryHandler(IServiceProvider serviceCollection, IMapper mapper)
            {
                _serviceCollection = serviceCollection;
                _mapper = mapper;
            }

            public async Task<List<CloudSellerDto>> Handle(GetSellerListQuery getProductListQuery)
            {
                using (var scope = _serviceCollection.CreateScope())
                {
                    var sellerRepository = scope.ServiceProvider.GetRequiredService<ISellerRepository>();
                    var product = await sellerRepository.GetSellers();
                    //var result = sellerRepository.GetMessage<dynamic>();
                    return _mapper.Map<List<CloudSellerDto>>(product);
                }
            }
        }
    }
}
