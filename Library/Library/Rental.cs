using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Rental
    {
        [Key]
        public int Id { get; set; }
        public virtual Book Book { get; set; }
        public virtual Customer Customers { get; set; }
        public virtual Employee Employee { get; set; }
        public DateTime RentalDate { get; set; }
        public DateTime? EndDate { get; set; }
        public Rental()
        {
        }

        public Rental(Book book, Customer customers, Employee employee,DateTime rentalDate)
        {
            Book = book;
            Customers = customers;
            Employee = employee;
            RentalDate = rentalDate;
        }
    }
}
