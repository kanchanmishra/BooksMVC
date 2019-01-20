using BooksDA.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDA.Interfaces
{    
        public interface ICatalog
        {
        List<Book> Books { get; set; }
    }    
}
