using Microsoft.VisualStudio.TestTools.UnitTesting;
using TestESAPi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ESAPIX.Facade.API;
using ESAPIX.Constraints;

namespace TestESAPi.ViewModels.Tests
{
    [TestClass()]
    public class CTDateConstraintTests
    {
        [TestMethod()]
        public void TestPasses()
        {
            //arrange
            var image = new Image();
            image.CreationDateTime = DateTime.Now.AddDays(-59);

            //Act

            var actual = new CTDateConstraint().Constrain(image).ResultType;

            //ASSERT

            var expected = ResultType.PASSED;
            Assert.AreEqual(expected, actual);
        }
        [TestMethod()]
        public void Testfail()
        {
            //arrange
            var image = new Image();
            image.CreationDateTime = DateTime.Now.AddDays(-61);

            //Act

            var actual = new CTDateConstraint().Constrain(image).ResultType;

            //ASSERT

            var expected = ResultType.ACTION_LEVEL_3;
            Assert.AreEqual(expected, actual);
        }
    }
}