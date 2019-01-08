using Microsoft.VisualStudio.TestTools.UnitTesting;
using Innergy.Recruitment.Jusko;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Innergy.Recruitment.Jusko.Tests
{
    [TestClass()]
    public class StockPresenterTests
    {
        [TestMethod()]
        public void WriteTest()
        {
            string output = @"WH-A (total 50)
[3M-Cherry-10mm]: 10
[COM-100001]: 5

WH-C (total 33)
[CB0115-CASSRC]: 10
[CB0115-CASSRC]: 3

";
            var list = new List<Warehouse>()
            {
                new Warehouse()
                {
                    Name="WH-A",
                    TotalQuantity=50,
                    Quantities=new List<WarehouseQuantity>()
                    {
                        new WarehouseQuantity(){Name="",Quantity=10,Material=new Material(){ Id="3M-Cherry-10mm"} },
                        new WarehouseQuantity(){Name="",Quantity=5,Material=new Material(){ Id="COM-100001"} },
                    }
                },
                new Warehouse()
                {
                    Name="WH-C",
                    TotalQuantity=33,
                    Quantities=new List<WarehouseQuantity>()
                    {
                        new WarehouseQuantity(){Name="",Quantity=10,Material=new Material(){ Id="CB0115-CASSRC"} },
                        new WarehouseQuantity(){Name="",Quantity=3,Material=new Material(){ Id="CB0115-CASSRC"} },
                    }
                }
            };
            TextWriter stringWriter = new StringWriter();
            using (var pres = new StockPresenter(stringWriter))
            {
                pres.Write(list);
                var result = stringWriter.ToString();
                Assert.IsTrue(string.Equals(output, result));
            }
         
        }
    }
}