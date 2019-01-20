using BooksDA.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Xml.Serialization;

namespace BooksDA.Models
{
    [XmlRoot(ElementName = "users")]
    public  class Users : IUsers
    {
        [XmlElement("user")]
        public List<User> UserDetails { get; set; }
    }
   
}
    
