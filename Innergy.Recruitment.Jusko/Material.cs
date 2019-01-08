using System.Collections.Generic;

namespace Innergy.Recruitment.Jusko
{
    public class Material
    {
        public string Name { get;  set; }
        public string Id { get;  set; }
        public List<WarehouseQuantity> Warehouses { get;  set; } = new List<WarehouseQuantity>();
    }
}