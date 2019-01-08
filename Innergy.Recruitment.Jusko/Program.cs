using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innergy.Recruitment.Jusko
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var stockParser = new StockParser(new InputProvider(Console.In, new LineValidator())))
            {
                using (StockPresenter presenter = new StockPresenter(Console.Out))
                {
                    presenter.Write(stockParser.Parse());
                }
            }
        }
    }
}
