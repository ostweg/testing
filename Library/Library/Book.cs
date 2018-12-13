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
        public string Description { get; set; }
        public string Author { get; set; }
        public int ISBN { get; set; }
        public double RentPriceCHF { get; set; }
        public string LanguageISO { get; set; }
        public Book()
        {

        }
        
    }
}
