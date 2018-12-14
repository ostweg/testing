using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library
{
    class Program
    {
        public static LibraryContext Context = new LibraryContext();
        static void Main(string[] args)
        {
            Employee e1 = new Employee();
            e1.FirstName = "John";
            e1.LastName = "Murrica";
            Context.Employee.Add(e1);
            Context.SaveChanges();
            Console.WriteLine("Enter Employee Firstname");
            string name = Console.ReadLine();
            if (EmployeeExist(name,e1.id))
            {
                Menu();
            }else
            {
                Console.WriteLine("Employee doesn't exits");
            }
            
            
        }

        static void Menu()
        {
            Console.WriteLine("Welcome to your Librarymanagment");
            Console.WriteLine("A: Create a Book");
            Console.WriteLine("B: Display Books");
            Console.WriteLine("C: Add a Customer");
            Console.WriteLine("D: Display Customers");
            Console.WriteLine("E: Add a Rental");
            Console.WriteLine("F: Return a Rental");
            Console.WriteLine("G: Display all open Rentals");
            string input = Console.ReadLine();
            switch (input)
            {
                case "A":
                    CreateBook();
                    break;
                case "B":
                    DisplayBook();
                    break;
                case "C":
                    CreateCustomer();
                    break;
                case "D":
                    DisplayCustomer();
                    break;
                case "E":
                    AddRental();
                    break;
                case "F":
                    //ReturnRental();
                    break;
                case "G":
                    //DisplayOpenRentals();
                    break;
                default:
                    Console.WriteLine("Invalid input");
                    Menu();
                    break;
                    
                    
            }

        }

        private static bool EmployeeExist(string employeefirstname, int id)
        {
            //string usr = Context.Employee.Find(employeefirstname).ToString();
            var usr1 = Context.Employee.Where(x => x.id == id && x.FirstName == employeefirstname).FirstOrDefault().ToString();
           
            if(usr1 != null)
            {
                return true;
            }
            return false;
        }

        private static void AddRental()
        {
            Console.WriteLine("Enter ISBN");
            int? BookISBN = Int32.Parse(Console.ReadLine());
            if (Context.Rental.Find(BookISBN).Book.ISBN == BookISBN)
            {
                Console.WriteLine("The Book is already rented");

            }

            Console.WriteLine("Enter the firstname of the Customer");
            var customerfirstname = Console.ReadLine();
            Rental rental = new Rental();
            rental.Book = Context.Book.Find(BookISBN);
            rental.Customers = Context.Customer.Find(customerfirstname);
            rental.RentalDate = DateTime.Today;
            //rental.Employee = employee
        }

        private static void CreateBook()
        {
            Console.WriteLine("Enter Title of book");
            var TitleOfBook = Console.ReadLine();
            Console.WriteLine("Enter short Description of book");
            var ShortDescriptionOfBook = Console.ReadLine();
            Console.WriteLine("Enter name of author");
            var NameOfAuthor = Console.ReadLine();
            Console.WriteLine("Enter isbn");
            var IsbnOfBook = Int32.Parse(Console.ReadLine());
            Console.WriteLine("Enter price/month in CHF");
            var PricePerMonth = Double.Parse(Console.ReadLine());
            Console.WriteLine("Enter language ISO");
            var LanguageIso = Console.ReadLine();


            Book b1 = new Book();
            b1.Title = TitleOfBook;
            b1.Description = ShortDescriptionOfBook;
            b1.Author = NameOfAuthor;
            b1.ISBN = IsbnOfBook;
            b1.LanguageISO = LanguageIso;
            b1.RentPriceCHF = PricePerMonth;
            Context.Book.Add(b1);
            Context.SaveChanges();



        }
    
        private static void DisplayCustomer()
        {
            foreach (var customer in Context.Customer)
            {
                Console.WriteLine("Name:{0} Firstname:{1} ",customer.LastName,customer.FirstName);

            }


        }

        private static void CreateCustomer()
        {
            Console.WriteLine("Enter the Customers Name");
            string lastname = Console.ReadLine();
            Console.WriteLine("Enter the Customers firstname");
            string firstname = Console.ReadLine();
            Customer customer = new Customer();
            customer.LastName = lastname;
            customer.FirstName = firstname;
            Context.Customer.Add(customer);
            Context.SaveChanges();

        }

        private static void DisplayBook()
        {
           
            foreach (var book in Context.Book)
            {
                Console.WriteLine("Booktitle:{0} Author:{1} ISBN{2} Rentprice:{3} Language:{4}",book.Title,book.Author,book.ISBN,book.RentPriceCHF,book.LanguageISO);
                
            }

        }
    } 
}
