using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BooksDA.Interfaces
{
    public interface IBookUser
    {
         string BookId { get; set; }
         string UserId { get; set; }
    }
}
