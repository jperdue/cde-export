using cde.district.validation.tests;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cde.district.validation.test
{
    [TestClass]
    public class BaseTestTest
    {
        [TestMethod]
        public void AssertSum()
        {
            GrowthGapsPointsRollup test = new GrowthGapsPointsRollup();

            Row row = new Row();
            row["TOTAL"] = "10";
            row["FIVE"] = "5";
            row["BLANK"] = "-";
            row["EMH_CODE"] = "M";

            Errors errors = new Errors();

            try
            {
                var result = test.AssertSum(row, "TOTAL", new[] { "FIVE", "FIVE", "BLANK" }, errors);
                Assert.IsTrue(result);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }
    }
}
