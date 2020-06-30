using System;
using System.Collections.Generic;
using System.Text;
using TripPlanner;

namespace Business
{
    public interface IXmlDataImport
    {
     
        public List<T> Read<T>(string fileName);
    }
}
