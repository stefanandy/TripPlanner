using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Business
{
    public interface IXmlDataExport
    {
        
        public void Write<T>(string fileName, List<T> listToWrite);

    }
}
