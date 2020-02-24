using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TripPlanner;

namespace Business.Tests
{
    [TestClass]
    public class XmlDataImportTests
    {
        private readonly IXmlDataImport dataImporter = new XmlDataImport();

        [TestMethod]
        public void ReadCustomers()
        {

            List<Customer> customers = new List<Customer>();

            for (int i = 0; i < 10; i++)
            {
                customers.Add(new Customer { FirstName = "Mr", LastName = "Test" });
            }

            var customersToCompareTo = dataImporter.Read<Customer>("customer.xml");

            Assert.AreEqual(customers.Count,customersToCompareTo.Count);

        }

    }
}
