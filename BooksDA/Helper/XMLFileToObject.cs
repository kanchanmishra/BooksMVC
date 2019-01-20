using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BooksDA.Helper
{
    public class XMLFileToObjectHelper
    {
        public static T XMLFileToObject<T>(string XmlFilename)
        {
            T returnObj = default(T);
            if (string.IsNullOrEmpty(XmlFilename)) return default(T);

            try
            {
                StreamReader xmlStream = new StreamReader(XmlFilename);
                XmlSerializer serializer = new XmlSerializer(typeof(T));
                returnObj = (T)serializer.Deserialize(xmlStream);
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return returnObj;
        }
    }
}
