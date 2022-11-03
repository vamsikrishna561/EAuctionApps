using E_Auction.Application.Interfaces;
using E_Auction.Domain.Interfaces.Cosmos;
using E_Auction.Application.DTOs.Cosmos;
using System;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Linq;
using System.Security.Cryptography.X509Certificates;

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
                    var buyerRepository = scope.ServiceProvider.GetRequiredService<IBuyerRepository>();
                    var product = sellerRepository.GetProductById(query.ProductId);
                    if (product == null)
                        return null;
                    var buyers = buyerRepository.GetBuyers();
                    if (buyers == null)
                        return null;
                    buyers.FindAll(x => {
                        return product.BuyerIds.Any(y => y == x.Email);
                    });
                    //var result = sellerRepository.GetMessage<dynamic>();
                    return _mapper.Map<CloudBidsDto>(buyers);
                }
            }
        }
    }
}
