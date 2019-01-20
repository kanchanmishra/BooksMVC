using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BooksDA.Models
{
    [XmlRoot(ElementName = "user")]
    public class User
    {
        [XmlAttribute("id")]
        public string Id { get; set; }

        [XmlElement("userName")]
        public string Name { get; set; }
    }
}
