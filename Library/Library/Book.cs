using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Book
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Beschreibung { get; set; }

        public Book()
        {

        }
    }
}
