using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Employee : Person
    {
        [Key]
        public int id { get; set; }
        public int Salary { get; set; }
    }
}
