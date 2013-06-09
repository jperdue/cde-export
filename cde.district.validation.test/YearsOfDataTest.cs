using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using cde.district.validation.tests;

namespace cde.district.validation.test
{
    [TestClass]
    public class YearsOfDataTest
    {
        [TestMethod]
        public void OneYear()
        {
            var yearsOfData = new YearsOfData();
            Assert.AreEqual("2011-12", yearsOfData.OneYear(2012));
            Assert.AreEqual("1999-00", yearsOfData.OneYear(2000));
        }

        [TestMethod]
        public void ThreeYear()
        {
            var yearsOfData = new YearsOfData();
            Assert.AreEqual("2009-10,2010-11,2011-12", yearsOfData.ThreeYear(2012));
        }
    }
}
