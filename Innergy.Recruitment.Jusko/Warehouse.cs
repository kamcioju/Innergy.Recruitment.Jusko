using System.Collections.Generic;

namespace Innergy.Recruitment.Jusko
{
    public class Warehouse
    {
        public string Name { get;   set; }
        public List<WarehouseQuantity> Quantities { get;   set; } = new List<WarehouseQuantity>();
        public int TotalQuantity { get;   set; }
    }
}