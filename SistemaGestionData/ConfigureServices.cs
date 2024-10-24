
using SistemaGestionData.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using SistemaGestionData.DataAccess;
using SistemaGestionEntities;

namespace SistemaGestionData;

public static class ConfigureServices
{
    public static IServiceCollection ConfigureDataLayer(this IServiceCollection services)
    {
        services.AddDbContext<CoderHouseContext>();

        services.AddScoped<ProductDataAccess>();
        services.AddScoped<UserDataAccess>();
        services.AddScoped<SellDataAccess>();
        services.AddScoped<SellProductEntity>();

        return services;
    }
}
