using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Program
    {
        static void Main(string[] args)
        {
            using(var dc= new LibraryContext())
            {
                Book b1 = new Book();
                b1.Title = "test";
                b1.Beschreibung = "test der teste";
                dc.book.Add(b1);
                dc.SaveChanges();

                dc.book.ToList().ForEach(x => Console.WriteLine(x.Title + x.Beschreibung));
            }      
        }
        
    }
}
