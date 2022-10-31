using E_Auction.Domain.Interfaces;
using E_Auction.Domain;
using E_Auction.Infrastructure.Messages;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using E_Auction.Infrastructure.Contexts;
using Microsoft.EntityFrameworkCore;

namespace E_Auction.Infrastructure.Utils
{
    public static class StartupExtensions
    {
        public static void AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (configuration.GetValue<bool>("Cosmos:Enabled"))
            {
                services.AddDbContext<CosmosContext>(options =>
                    options.UseCosmos(
                        configuration["Cosmos:AccountEndpoint"],
                        configuration["Cosmos:AccountKey"],
                        configuration["Cosmos:DatabaseName"])
                );
                services.AddScoped<Domain.Interfaces.Cosmos.ISellerRepository, Repositories.Cosmos.SellerRepository>();
                services.AddScoped<Domain.Interfaces.Cosmos.IBuyerRepository, Repositories.Cosmos.BuyerRepository>();
                services.AddScoped<IMessageProducer, MessageProducer>();
            }
            else
            {
                services.AddDbContext<EAuctionContext>(options =>
            options.UseSqlServer(
                configuration.GetConnectionString("EAUCTION")
                ));
                services.AddScoped<ISellerRepository, Repositories.SellerRepository>();
                services.AddScoped<IBuyerRepository, Repositories.BuyerRepository>();
                services.AddScoped<IMessageProducer, MessageProducer>();
                services.Configure<RabbitMq>(configuration.GetSection("RabbitMq"));
            }
        }
    }
}
