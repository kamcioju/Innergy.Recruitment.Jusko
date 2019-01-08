// <copyright file="LineValidatorTest.cs">Copyright ©  2019</copyright>
using System;
using Innergy.Recruitment.Jusko;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Innergy.Recruitment.Jusko.Tests
{
    /// <summary>Ta klasa zawiera sparametryzowane testy jednostek dla LineValidator</summary>
    [PexClass(typeof(LineValidator))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class LineValidatorTest
    {
        /// <summary>Zastępcza klasa testowa dla .ctor()</summary>
        [PexMethod]
        public LineValidator ConstructorTest()
        {
            LineValidator target = new LineValidator();
            return target;
            // TODO: dodaj asercje do metoda LineValidatorTest.ConstructorTest()
        }

        /// <summary>Zastępcza klasa testowa dla Validate(String)</summary>
        [PexMethod]
        public bool ValidateTest([PexAssumeUnderTest]LineValidator target, string line)
        {
            bool result = target.Validate(line);
            return result;
            // TODO: dodaj asercje do metoda LineValidatorTest.ValidateTest(LineValidator, String)
        }
    }
}
