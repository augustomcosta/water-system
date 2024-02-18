using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WaterSystem.Infra.Context;

namespace WaterSystem.Infra.IoC;

public class DependencyInjection
{
    public IServiceCollection AddInfrastructure(IServiceCollection services, IConfiguration config)
    {
        AddDbContext(services,config);
        return services;
    }

    private static void AddDbContext(IServiceCollection services, IConfiguration config)
    {
        services.AddDbContext<AppDbContext>(options => options.UseNpgsql(
            config.GetConnectionString("DefaultConnection"),
            b => b.MigrationsAssembly("WaterSystem.API")
            ));
    }
}