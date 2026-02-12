using System;
using System.Collections.Generic;
using System.Linq;

namespace LibraryManagementSystem
{
    class Program
    {

        static List<dynamic> bookCollection = new List<dynamic>();
        static int idCounter = 1;

        static void Main(string[] args)
        {
            while (true)
            {
                Console.WriteLine("\n===== BOOK LIBRARY MANAGEMENT SYSTEM =====");
                Console.WriteLine("1. Admin Panel");
                Console.WriteLine("2. User Panel");
                Console.WriteLine("3. Exit");
                Console.Write("Select Option: ");

                int choice = Convert.ToInt32(Console.ReadLine());

                switch (choice)
                {
                    case 1:
                        AdminMenu();
                        break;
                    case 2:
                        UserMenu();
                        break;
                    case 3:
                        return;
                    default:
                        Console.WriteLine("Invalid Choice!");
                        break;
                }
            }
        }

        static void AdminMenu()
        {
            Console.WriteLine("\n--- ADMIN PANEL ---");
            Console.WriteLine("1. Add Book");
            Console.WriteLine("2. Update Book");
            Console.WriteLine("3. Delete Book");
            Console.WriteLine("4. View All Books");
            Console.Write("Select Option: ");

            int adminChoice = Convert.ToInt32(Console.ReadLine());

            switch (adminChoice)
            {
                case 1:
                    AddBook();
                    break;
                case 2:
                    UpdateBook();
                    break;
                case 3:
                    DeleteBook();
                    break;
                case 4:
                    ViewBooks();
                    break;
                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }

        static void AddBook()
        {
            dynamic book = new System.Dynamic.ExpandoObject();

            book.Id = idCounter++;
            Console.Write("Enter Book Name: ");
            book.Name = Console.ReadLine();

            Console.Write("Enter Publisher: ");
            book.Publisher = Console.ReadLine();

            Console.Write("Enter Price: ");
            book.Price = Convert.ToDouble(Console.ReadLine());

            bookCollection.Add(book);

            Console.WriteLine("Book Added Successfully!");
        }

        static void UpdateBook()
        {
            Console.Write("Enter Book ID to Update: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var book = bookCollection.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                Console.Write("Enter New Book Name: ");
                book.Name = Console.ReadLine();

                Console.Write("Enter New Publisher: ");
                book.Publisher = Console.ReadLine();

                Console.Write("Enter New Price: ");
                book.Price = Convert.ToDouble(Console.ReadLine());

                Console.WriteLine("Book Updated Successfully!");
            }
            else
            {
                Console.WriteLine("Book Not Found!");
            }
        }

        static void DeleteBook()
        {
            Console.Write("Enter Book ID to Delete: ");
            int id = Convert.ToInt32(Console.ReadLine());

            var book = bookCollection.FirstOrDefault(b => b.Id == id);

            if (book != null)
            {
                bookCollection.Remove(book);
                Console.WriteLine("Book Deleted Successfully!");
            }
            else
            {
                Console.WriteLine("Book Not Found!");
            }
        }

        static void ViewBooks()
        {
            if (bookCollection.Count == 0)
            {
                Console.WriteLine("No Books Available!");
                return;
            }

            Console.WriteLine("\n--- BOOK LIST ---");
            foreach (var book in bookCollection)
            {
                Console.WriteLine($"ID: {book.Id} | Name: {book.Name} | Publisher: {book.Publisher} | Price: {book.Price}");
            }
        }


        static void UserMenu()
        {
            Console.WriteLine("\n--- USER PANEL ---");
            Console.WriteLine("1. Browse Books");
            Console.WriteLine("2. Search by Name");
            Console.WriteLine("3. Search by Publisher");
            Console.WriteLine("4. Highest Price Book");
            Console.WriteLine("5. Lowest Price Book");
            Console.Write("Select Option: ");

            int userChoice = Convert.ToInt32(Console.ReadLine());

            switch (userChoice)
            {
                case 1:
                    ViewBooks();
                    break;
                case 2:
                    SearchByName();
                    break;
                case 3:
                    SearchByPublisher();
                    break;
                case 4:
                    HighestPriceBook();
                    break;
                case 5:
                    LowestPriceBook();
                    break;
                default:
                    Console.WriteLine("Invalid Choice!");
                    break;
            }
        }

        static void SearchByName()
        {
            Console.Write("Enter Book Name: ");
            string name = Console.ReadLine();

            var results = bookCollection
                .Where(b => b.Name.ToLower().Contains(name.ToLower()))
                .ToList();

            if (results.Count > 0)
            {
                foreach (var book in results)
                {
                    Console.WriteLine($"ID: {book.Id} | Name: {book.Name} | Publisher: {book.Publisher} | Price: {book.Price}");
                }
            }
            else
            {
                Console.WriteLine("No Matching Books Found!");
            }
        }

        static void SearchByPublisher()
        {
            Console.Write("Enter Publisher Name: ");
            string publisher = Console.ReadLine();

            var results = bookCollection
                .Where(b => b.Publisher.ToLower().Contains(publisher.ToLower()))
                .ToList();

            if (results.Count > 0)
            {
                foreach (var book in results)
                {
                    Console.WriteLine($"ID: {book.Id} | Name: {book.Name} | Publisher: {book.Publisher} | Price: {book.Price}");
                }
            }
            else
            {
                Console.WriteLine("No Matching Books Found!");
            }
        }

        static void HighestPriceBook()
        {
            if (bookCollection.Count == 0)
            {
                Console.WriteLine("No Books Available!");
                return;
            }

            var book = bookCollection.OrderByDescending(b => b.Price).First();

            Console.WriteLine("\nHighest Price Book:");
            Console.WriteLine($"ID: {book.Id} | Name: {book.Name} | Publisher: {book.Publisher} | Price: {book.Price}");
        }

        static void LowestPriceBook()
        {
            if (bookCollection.Count == 0)
            {
                Console.WriteLine("No Books Available!");
                return;
            }

            var book = bookCollection.OrderBy(b => b.Price).First();

            Console.WriteLine("\nLowest Price Book:");
            Console.WriteLine($"ID: {book.Id} | Name: {book.Name} | Publisher: {book.Publisher} | Price: {book.Price}");
        }
    }
}
