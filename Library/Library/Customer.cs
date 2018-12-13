using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Customer : Person
    {
        public List<Book> RentedBooks { get;set; }
        
    }
}
