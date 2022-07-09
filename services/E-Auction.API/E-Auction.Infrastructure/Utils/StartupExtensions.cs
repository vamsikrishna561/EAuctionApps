using E_Auction.Domain.Interfaces;
using E_Auction.Infrastructure.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Auction.Infrastructure.Utils
{
    public static class StartupExtensions
    {
        public static void AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<ISellerRepository, SellerRepository>();
        }
    }
}
