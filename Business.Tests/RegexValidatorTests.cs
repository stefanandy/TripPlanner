using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Tests
{
    [TestClass]
    public class RegexValidatorTests
    {
        private readonly IRegexValidator validator= new RegexValidator();

        [TestMethod]
        public void ValidateEmail()
        {
            string email = "test@gmail.com";

            var result = validator.ValidateEmail(email);

            Assert.AreEqual(true,result);
        }

        [TestMethod]
        public void ValidatePhoneNumber()
        {
            string phoneNumber = "+40731 467389";

            var result = validator.ValidatePhoneNumber(phoneNumber);

            Assert.AreEqual(true, result);
        }

        [TestMethod]
        public void ValidateName()
        {
            string name = "Stefan Andrei";

            var result = validator.ValidateName(name);

            Assert.AreEqual(true, result);

        }

    }
}
