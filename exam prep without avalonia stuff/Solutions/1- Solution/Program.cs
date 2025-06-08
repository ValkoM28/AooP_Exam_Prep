using System;
using System.Collections.Generic;

namespace LibraryTracker
{
    class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }
        public int YearPublished { get; set; }
        public bool IsCheckedOut { get; set; }

        // Default constructor
        public Book()
        {
            Title = "Unknown";
            Author = "Unknown";
            YearPublished = 0;
            IsCheckedOut = false;
        }

        // Parameterized constructor
        public Book(string title, string author, int yearPublished, bool isCheckedOut)
        {
            Title = title;
            Author = author;
            YearPublished = yearPublished;
            IsCheckedOut = isCheckedOut;
        }
    }

    class Library
    {
        private List<Book> books = new List<Book>();

        public void AddBook(Book book)
        {
            books.Add(book);
        }

        public void DisplayBooks()
        {
            Console.WriteLine("Library Books:");
            Console.WriteLine("---------------");

            foreach (var book in books)
            {
                Console.WriteLine($"Title: {book.Title}, Author: {book.Author}, Year: {book.YearPublished}, Checked Out: {book.IsCheckedOut}");
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Using parameterized constructors
            Book book1 = new Book("The Hobbit", "J.R.R. Tolkien", 1937, false);
            Book book2 = new Book("1984", "George Orwell", 1949, true);

            // Using object initializer syntax
            Book book3 = new Book
            {
                Title = "Clean Code",
                Author = "Robert C. Martin",
                YearPublished = 2008,
                IsCheckedOut = false
            };

            Book book4 = new Book
            {
                Title = "Dune",
                Author = "Frank Herbert",
                YearPublished = 1965,
                IsCheckedOut = true
            };

            Library library = new Library();

            library.AddBook(book1);
            library.AddBook(book2);
            library.AddBook(book3);
            library.AddBook(book4);

            library.DisplayBooks();
        }
    }
}
