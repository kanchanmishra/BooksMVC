using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BooksDA.Models
{
    [XmlRoot(ElementName = "book")]
    public class Book
    {
        [XmlAttribute("id")]
        public string BookId { get; set; }

        [XmlElement("author")]
        public string Author { get; set; }

        [XmlElement("title")]
        public string Title { get; set; }

        [XmlElement("genre")]
        public string Genre { get; set; }

        [XmlElement("price")]
        public string Price { get; set; }

        [XmlElement("publish_date")]
        public DateTimeOffset PublishDate { get; set; }

        [XmlElement("description")]
        public string Description { get; set; }

        public string WhoBorrowed { get; set; }
    }
}
