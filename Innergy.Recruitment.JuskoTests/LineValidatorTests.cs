using Microsoft.VisualStudio.TestTools.UnitTesting;
using Innergy.Recruitment.Jusko;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Innergy.Recruitment.Jusko.Tests
{
    [TestClass()]
    public class LineValidatorTests
    {
       
        [TestMethod()]
        [TestCategory("Validator")]
        public void ValidatePositiveTest()
        {
            var validator = new LineValidator();
            Assert.IsTrue(validator.Validate("Hdw Accuride CB0115-CASSRC - Locking Handle Kit - Black;CB0115-CASSRC;WH-C,10|WH-B, 5 | WH - C, 3"));
            Assert.IsTrue(validator.Validate("Veneer - Charter Industries - 3M Adhesive Backed - Cherry 10mm - Paper Back;3M-Cherry - 10mm; WH - A,10 | WH - B,1"));
       
        }
        [TestMethod()]
        [TestCategory("Validator")]
        public void ValidateNegativeTest()
        {
            var validator = new LineValidator();
            Assert.IsFalse(validator.Validate("Veneer - Charter Industries - 3M Adhesive Backed - Cherry 10mm"));
            Assert.IsFalse(validator.Validate("# Existing materials, restocked"));
        }
        [TestMethod()]
        [TestCategory("Validator")]
        [ExpectedExceptionAttribute(typeof(ArgumentException))]
        public void ValidateExceptionTest()
        {
            var validator = new LineValidator() { SuppressExceptions = false };
            validator.Validate("Veneer - Charter Industries - 3M Adhesive Backed - Cherry 10mm");
            validator.Validate("# Existing materials, restocked");
        }
    }
}