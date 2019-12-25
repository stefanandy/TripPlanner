using System;
using System.Collections.Generic;
using System.Text;
using TripPlanner;

namespace Business
{
    public interface IDataExporter
    {
        void WriteCustomers(string filePath, Customer[] customers);
        public void WriteEncryptedCustomers(string inputFile, string outputFile);
    }
}
