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

        services.AddScoped<ProductosServices>();
        services.AddScoped<UsuarioServices>();
        services.AddScoped<VentaServices>();
        services.AddScoped<ProductoVendidoServices>();

        

        return services;
    }
}
