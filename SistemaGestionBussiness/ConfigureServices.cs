using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using SistemaGestionBussiness.Services;
using SistemaGestionData;


namespace SistemaGestionBussiness;

public static class ConfigureServices
{
    public static IServiceCollection ConfigureBusinessLayer(this IServiceCollection services)
    {
        services.ConfigureDataLayer();

        services.AddScoped<ProductsServices>();
        services.AddScoped<UserServices>();
        services.AddScoped<SellServices>();
        services.AddScoped<SellProductsServices>();

        

        return services;
    }
}
