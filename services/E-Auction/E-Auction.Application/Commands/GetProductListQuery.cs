using CSharpFunctionalExtensions;
using E_Auction.Application.DTOs;
using E_Auction.Application.Interfaces;
using E_Auction.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Application.Commands
{
    public sealed class GetProductListQuery : IQuery<List<ProductDto>>
    {
        public int SellerId { get; set; }
        public sealed class GetProductListQueryHandler : IQueryHandler<GetProductListQuery,List<ProductDto>>
        {
            private readonly ISellerRepository _sellerRepository;
            public GetProductListQueryHandler(ISellerRepository sellerRepository)
            {
                _sellerRepository = sellerRepository ?? throw new ArgumentNullException();
            }

            public async Task<List<ProductDto>> Handle(GetProductListQuery getProductListQuery)
            {
                throw new NotImplementedException();
            }
        }
    }
}
