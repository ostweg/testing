using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Customer : Person
    {
        [Key]
        public int id { get; set; }
        public List<Book> RentedBooks { get;set; }
        
    }
}
