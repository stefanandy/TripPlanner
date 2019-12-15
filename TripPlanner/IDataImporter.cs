using System;
using System.Collections.Generic;
using System.Text;
using TripPlanner;

namespace Business
{
    public interface IDataImporter
    {
        public Customer[] ReadCustomers(string filePath);
    }
}
