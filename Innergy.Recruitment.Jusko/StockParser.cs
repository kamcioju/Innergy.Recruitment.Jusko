using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innergy.Recruitment.Jusko
{
   public class StockParser : IDisposable
    {
        public void Dispose() => _prov.Dispose();
        private InputProvider _prov;
        public StockParser(InputProvider prov)
        {
            _prov = prov;
        }

        public IList<Warehouse> Parse()
        {
            List<Warehouse> globalWarehouses = new List<Warehouse>();
            foreach (var line in _prov.ReadValidLines())
            {
                var itemData = line.Split(';');
                Material m = new Material()
                {
                    Name = itemData[0],
                    Id = itemData[1],
                };
                var warehouseString = itemData[2].Split('|');
                m.Warehouses = ExtractWarehouses(warehouseString, m, globalWarehouses);

            }
            return globalWarehouses;
        }

        private static List<WarehouseQuantity> ExtractWarehouses(string[] warehouses, Material m, List<Warehouse> globalWarehouses)
        {

            List<WarehouseQuantity> result = new List<WarehouseQuantity>();
            foreach (var item in warehouses)
            {
                var data = item.Split(',');
                WarehouseQuantity w = new WarehouseQuantity()
                {
                    Name = data[0],
                    Quantity = Convert.ToInt32(data[1]),
                };
                var warehouse = globalWarehouses.FirstOrDefault(x => x.Name == w.Name);
                if (warehouse == null)
                {
                    warehouse = new Warehouse() { Name = w.Name };
                    globalWarehouses.Add(warehouse);
                }
                warehouse.Quantities.Add(w);
                warehouse.TotalQuantity += w.Quantity;
                w.Material = m;
                result.Add(w);
            }
            return result;
        }


    }
}
