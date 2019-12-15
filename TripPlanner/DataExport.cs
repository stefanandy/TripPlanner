using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TripPlanner;
using CsvHelper;
using System.Security.Cryptography;

namespace Business
{
    public class DataExport : IDataExporter
    {
        public void WriteCustomers(string filePath, Customer[] customers)
        {

            using (var writer=new StreamWriter(filePath,false,Encoding.UTF8) )
            {
                using (var csv=new CsvWriter(writer) )
                {
                    csv.WriteRecords(customers);
                }
            }
            
        }


        public void WriteEncryptedCustomers(string inputFile, string outputFile) 
        {
            string password = @"myKey123";
            UnicodeEncoding UE = new UnicodeEncoding();
            byte[] key = UE.GetBytes(password);

            using (FileStream fileToWrite = new FileStream(outputFile, FileMode.Create))
            {

                RijndaelManaged algortim = new RijndaelManaged();

                using (CryptoStream crypt = new CryptoStream(fileToWrite, algortim.CreateEncryptor(key, key), CryptoStreamMode.Write))
                {

                    using (FileStream fileToRead = new FileStream(inputFile, FileMode.Open))
                    {

                        int data;

                        while ((data = fileToRead.ReadByte()) != -1)
                        {
                            crypt.WriteByte((byte)data);
                        }

                    }
                }
            }
        }
    }
}
