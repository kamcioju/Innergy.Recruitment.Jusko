using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Innergy.Recruitment.Jusko
{
    public class StockPresenter:IDisposable
    {
        private TextWriter _output;

        public StockPresenter(TextWriter @out)
        {
            this._output = @out;
        }

        public void Dispose()
        {
            _output.Dispose();
        }

        public void Write(IList<Warehouse> list)
        {
            foreach(var warehouse in list.OrderByDescending(x=>x.TotalQuantity).ThenByDescending(x=>x.Name))
            {
                _output.WriteLine($@"{warehouse.Name} (total {warehouse.TotalQuantity})");
                foreach(var product in warehouse.Quantities.OrderBy(x=>x.Material.Id))
                {
                    _output.WriteLine($@"[{product.Material.Id}]: {product.Quantity}");
                }
                _output.WriteLine();
            }
        }
    }
}