using Microsoft.VisualStudio.TestTools.UnitTesting;
using TripPlanner;

namespace Business.Tests
{
    [TestClass]
    public class DataImportTests
    {
        [TestMethod]
        public void Count_Customers()
        {
            IDataImporter importer = new DataImporter();

            string filePath = @"C:\Users\Lejer\source\repos\AnimalsHomework\TripPlanner\inputCustomers.csv";
            Customer[] customers = importer.ReadCustomers(filePath);
            Assert.AreEqual(1400, customers.Length);
        }
    }

   
}