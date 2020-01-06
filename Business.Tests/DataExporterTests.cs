using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;
using TripPlanner;

namespace Business.Tests
{
    [TestClass]
    public class DataExporterTests
    {
        private IDataExporter dataExporter = new DataExport();
        private IInterrogator interogator;

        [TestMethod]
        public void WriteCustomers_ForResultOfFindByName()
        {

            HotelBuilder hotelBuilder = new HotelBuilder();
            Hotel hotel = hotelBuilder.CreateHotel(0, 0);

            DataImporter dataImporter = new DataImporter();

            string filePathImport = @"../../../../TripPlanner/inputCustomers.csv";
            Customer[] customersFromCsv = dataImporter.ReadCustomers(filePathImport);

            for (int i = 0; i < customersFromCsv.Length; i++)
            {
                hotel.AddCustomer(customersFromCsv[i]);
            }

            interogator = new Interrogator(hotel);

            Customer[] customers = interogator.FindByName("Nero");
            string filePath = @"../../../../TripPlanner/findByName.csv";
            dataExporter.WriteCustomers(filePath, customers);
        }

        [TestMethod]
        public void WriteCustomers_ForCustomersGroupedByCountry()
        {

            HotelBuilder hotelBuilder = new HotelBuilder();
            Hotel hotel = hotelBuilder.CreateHotel(0, 0);

            DataImporter dataImporter = new DataImporter();

            string filePathImport = @"../../../../TripPlanner/inputCustomers.csv";
            Customer[] customersFromCsv = dataImporter.ReadCustomers(filePathImport);

            for (int i = 0; i < customersFromCsv.Length; i++)
            {
                hotel.AddCustomer(customersFromCsv[i]);
            }

            interogator = new Interrogator(hotel);

            Customer[] customers = interogator.FindFirstCustomersGroupedByCountry();
            string filePath = @"../../../../TripPlanner/findCustomersGroupedByCountry.csv";
            dataExporter.WriteCustomers(filePath, customers);
        }

        [TestMethod]
        public void WriteEncryptedCustomers()
        {
            string inputFile = @"../../../../TripPlanner/inputCustomers.csv";
            string outputFile= @"../../../../TripPlanner/encryptedCustomers.csv";

            IDataExporter exporter = new DataExport();
            exporter.WriteEncryptedCustomers(inputFile,outputFile);
        }
    }

   
}
