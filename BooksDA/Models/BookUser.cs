using BooksDA.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDA.Models
{
    public class BookUser : IBookUser
    {
        public string BookId { get ; set; }
        public string UserId { get; set; }
    }
}
