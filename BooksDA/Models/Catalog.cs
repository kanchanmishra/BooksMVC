using BooksDA.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;


namespace BooksDA.Models
{
    [XmlRoot(ElementName = "catalog")]
    public  class Catalog  : ICatalog
    {
        [XmlElement("book")]
        public List<Book> Books { get; set; }
    }
    
}
