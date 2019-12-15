using System;
using System.Collections.Generic;
using System.Text;
using System.Collections;
using TripPlanner;

namespace Business
{
    public interface IDataImporter
    {
        public Customer[] ReadCustomers(string filePath);
       public ArrayList ReadRooms(string filePath);
       public Queue<Reservation> ReadReservations(string filePath);

        public void ReadEncryptedCustomers(string inputFile, string outputFile);
    }
}
