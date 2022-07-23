using E_Auction.Domain.Interfaces;
using E_Auction.Domain;
using E_Auction.Infrastructure.Messages;
using E_Auction.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
   

namespace E_Auction.Infrastructure.Utils
{
    public static class StartupExtensions
    {
        public static void AddRepositories(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ISellerRepository, SellerRepository>();
            services.AddScoped<IBuyerRepository, BuyerRepository>();
            services.AddScoped<IMessageProducer, MessageProducer>();
            services.Configure<RabbitMq>(configuration.GetSection("RabbitMq"));
        }
    }
}
