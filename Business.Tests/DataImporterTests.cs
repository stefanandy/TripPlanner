using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;
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

            string filePath = @"../../../../TripPlanner/inputCustomers.csv";
            Customer[] customers = importer.ReadCustomers(filePath);
            Assert.AreEqual(1400, customers.Length);
        }

        [TestMethod]
        public void ReadRooms_FromFile_Is_Successful()
        {
            IDataImporter importer = new DataImporter();

            string filePath = @"../../../../TripPlanner/inputRooms.csv";
            ArrayList rooms = importer.ReadRooms(filePath);
            Assert.AreEqual(32, rooms.Count);
        }

        [TestMethod]
        public void ReadReservations_FromFile_Is_Successful()
        {
            IDataImporter importer = new DataImporter();

            string filePath = @"../../../../TripPlanner/inputReservations.csv";
            Queue<Reservation> reservations = importer.ReadReservations(filePath);
            Assert.AreEqual(194, reservations.Count);
        }


        [TestMethod]
        public void Read_Encrypted_Customers_File() {
            IDataImporter importer = new DataImporter();

            string inputFile = @"../../../../TripPlanner/encryptedCustomers.csv";
            string outputFile = @"../../../../TripPlanner/decryptedCustomers.csv";

            importer.ReadEncryptedCustomers(inputFile,outputFile);

        }

    }

   
}