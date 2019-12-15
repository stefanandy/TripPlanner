using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using TripPlanner;
using System.Collections;
using CsvHelper;
using CsvHelper.Configuration;
using System.Linq;
using System.Globalization;
using System.Security.Cryptography;

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
                    
                    customers.Add(new Customer(line));

                }
            
            }
            return customers.ToArray();
        }

        public ArrayList ReadRooms(string filePath) {
            List<Room> rooms = new List<Room>();
            using (var reader = new StreamReader(filePath))
            {

                reader.ReadLine();

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    rooms.Add(new Room(line));

                }

            }

            var arrayList = new ArrayList(rooms);

            return arrayList;
        }


        public Queue<Reservation> ReadReservations(string filePath) {
            List<Reservation> reservations = new List<Reservation>();

            using (var reader = new StreamReader(filePath))
            {

                reader.ReadLine();

                while (!reader.EndOfStream)
                {

                    var line = reader.ReadLine();

                    reservations.Add(new Reservation(line));

                }

            }

            var queue = new Queue<Reservation>(reservations);

            return queue;
        }

        public void ReadEncryptedCustomers(string inputFile, string outputFile)
        {
            string password = @"myKey123"; 

            UnicodeEncoding encoding = new UnicodeEncoding();
            byte[] key = encoding.GetBytes(password);

            using (FileStream fileToRead = new FileStream(inputFile, FileMode.Open))
            {
                RijndaelManaged algoritm = new RijndaelManaged();

                using (CryptoStream crypt = new CryptoStream(fileToRead, algoritm.CreateDecryptor(key, key), CryptoStreamMode.Read))
                {
                    using (FileStream cryptedFile = new FileStream(outputFile, FileMode.Create))
                    {

                        int data;
                        while ((data = crypt.ReadByte()) != -1)
                            cryptedFile.WriteByte((byte)data);

                    }
                }
            }

        }

    }

   


    
    
}
