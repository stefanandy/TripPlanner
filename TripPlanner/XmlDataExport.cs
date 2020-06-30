using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace Business
{
    public class XmlDataExport : IXmlDataExport
    {
        
        
        public void Write<T>(string fileName, List<T> listToWrite) {
            using (var stream = new FileStream(fileName, FileMode.Create))
            {
                var xml = new XmlSerializer(typeof(List<T>));
                xml.Serialize(stream, listToWrite);
            }
        
        }

    }
}
