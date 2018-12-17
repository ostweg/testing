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
            Console.WriteLine("Enter Employee Lastname");
            string lastname = Console.ReadLine();
            if (EmployeeExist(name,lastname))
            {
                Menu();
            }
            else
            {
                Console.WriteLine("Wrong employee");
                Environment.Exit(1);
            }
            
            
        }

        static void Menu()
        {
            string input;
            do
            {


                Console.WriteLine("Welcome to your Librarymanagment");
                Console.WriteLine("A: Create a Book");
                Console.WriteLine("B: Display Books");
                Console.WriteLine("C: Add a Customer");
                Console.WriteLine("D: Display Customers");
                Console.WriteLine("E: Add a Rental");
                Console.WriteLine("F: Return a Rental");
                Console.WriteLine("G: Display all open Rentals");
                input = Console.ReadLine();
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
                        ReturnRental();
                        break;
                    case "G":
                        DisplayOpenRentals();
                        break;
                    case "e": Environment.Exit(1);
                        break;
                    default:
                        Console.WriteLine("Invalid input");
                        Menu();
                        break;


                }
            } while (input != "e");
        } 


        

        private static void DisplayOpenRentals()
        {
            foreach (var rental in Context.Rental)
            {
                Console.WriteLine("Customer: {0},{1} has rented this Book: {2} since {3}",rental.Customers.LastName, rental.Customers.FirstName, rental.Book.Title,rental.RentalDate);
                
            }
        }

        private static void ReturnRental()
        {
            Console.WriteLine("Enter the Books ISBN");
            string ISBN = Console.ReadLine();
            var rental = Context.Rental.Find(ISBN);
            if (rental != null)
            {
                rental.EndDate = DateTime.Today;
                var datediff = DateTime.Today - rental.RentalDate;
                var price =  rental.Book.RentPriceCHF / 7 * 0.1 * datediff.TotalDays;
                Console.WriteLine("The rental costed:{0}",price);
                Context.SaveChanges();
            }
        }

        private static bool EmployeeExist(string employeefirstname, string employeelastname)
        {
            //string usr = Context.Employee.Find(employeefirstname).ToString();
           
            try
            {
                var usr1 = Context.Employee.FirstOrDefault(x => x.LastName == employeelastname && x.FirstName == employeefirstname)?.ToString();
                if (usr1 != null)
                {
                    return true;
                }
                
            }catch(Exception)
            {
                Console.WriteLine("Employee doesn't exits");
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
