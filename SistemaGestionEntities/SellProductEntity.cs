using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SistemaGestionEntities;

public class SellProductEntity
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public int Stock { get; set; }
    public int SellId { get; set; }
}