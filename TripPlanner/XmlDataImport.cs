using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;
using TripPlanner;

namespace Business
{
    public class XmlDataImport : IXmlDataImport
    {
       

        public List<T> Read<T>(string fileName)
        {
            using (var stream = new FileStream(fileName, FileMode.Open))
            {
                var xml = new XmlSerializer(typeof(List<T>));
                return (List<T>)xml.Deserialize(stream);
            }
        }
    }
}
