

using Microsoft.EntityFrameworkCore;
using SistemaGestionEntities;


using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionData.Context;

public class CoderHouseContext : DbContext
{
    public DbSet<Producto> Productos { get; set; }

    public CoderHouseContext() : base()
    {
    }

    public CoderHouseContext(DbContextOptions<CoderHouseContext> options) : base(options)
    {
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer("Server=WIN11-OMV\\SQL2022;Initial Catalog=CoderProyectoFinal;Integrated Security=True;TrustServerCertificate=True");
        }
    }

    public DbSet<Usuario> Usuarios { get; set; }
    
    public DbSet<ProductoVendido> ProductosVendidos { get; set; }
    public DbSet<Venta> Ventas { get; set; }
}
