

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
    public DbSet<Product> Products { get; set; }

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
            optionsBuilder.UseSqlServer("Server=PENTANB58\\SQL2022;Initial Catalog=CoderProyectoFinal;Integrated Security=True;TrustServerCertificate=True");
        }
    }

    public DbSet<UserEntity> Users { get; set; }
    public DbSet<SellProductEntity> SellProducts { get; set; }
    public DbSet<SellEntity> Sells { get; set; }
}
