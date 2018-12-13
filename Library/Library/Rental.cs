﻿using System;
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
        public Book Book { get; set; }
        public Customer Customers { get; set; }
        public Employee Employee { get; set; }

        public Rental(Book book, Customer customers, Employee employee)
        {
            Book = book;
            Customers = customers;
            Employee = employee;
        }
    }
}