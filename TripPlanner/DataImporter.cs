using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TripPlanner;
using CsvHelper;
using CsvHelper.Configuration;
using System.Linq;
using System.Globalization;

namespace Business
{
    public class DataImporter:IDataImporter
    {


        public Customer[] ReadCustomers(string filePath)
        {
            List<Customer> customers = new List<Customer>();

            using (var reader = new StreamReader(filePath)) {

                reader.ReadLine();
                
                while (!reader.EndOfStream ) {

                    var line = reader.ReadLine();
                    
                    customers.Add(Customer.Parse(line));

                }
            
            }
            return customers.ToArray();
        }



    }


    
    
}
