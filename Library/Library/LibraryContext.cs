using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class LibraryContext : DbContext
    {

        public DbSet<Book> Book { get; set; }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Customer> Customer { get; set; }
    }
}
