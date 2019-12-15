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

            string cryptFile = outputFile;

            FileStream fsCrypt = new FileStream(cryptFile, FileMode.Create);

            RijndaelManaged RMCrypto = new RijndaelManaged();

            CryptoStream cs = new CryptoStream(fsCrypt, RMCrypto.CreateEncryptor(key,key),CryptoStreamMode.Write);

            FileStream fsIn = new FileStream(inputFile, FileMode.Open);

            int data;

            while ((data=fsIn.ReadByte())!=-1) {
                cs.WriteByte((byte)data);
            }

            fsIn.Close();
            cs.Close();
            fsCrypt.Close();
        }
    }
}
