using System;
using System.Collections;
using Bookstore;

/*
// 2024/03/29 : C# ButtonTest, 대리자(microsoft 공식 예제)

// C# 공부 자료
// microsoft 공식 자료, C# 스터디

*/

namespace Bookstore
{
    public struct Book      // 구조체는 stack에 메모리 잡혀서 생성자 작성 시 반드시 초기화를 해줘야 한다.
    {
        public string Title;
        public string Author;
        public decimal Price;
        public bool Paperback;

        public Book(string title, string author, decimal price, bool paperback)
        {
            Title = title;
            Author = author;
            Price = price;
            Paperback = paperback;
        }
    }

    public delegate void ProcessBookDelegate(Book book);

    public class BookDB
    {
        ArrayList list = new ArrayList();

        public void AddBook(string title, string author, decimal price, bool paperbook)
        {
            list.Add(new Book(title, author, price, paperbook));
        }

        public void ProcessPaperbackBooks(ProcessBookDelegate processBook)
        {
            foreach (Book book in list)
            {
                if (book.Paperback)
                {
                    processBook(book);
                }
            }
        }
    }
}

namespace day10
{
    class PriceToTaller
    {
        int countBooks = 0;
        decimal priceBooks = 0.0m;

        internal void AddBookToTotal(Book book)
        {
            countBooks += 1;
            priceBooks += book.Price;
        }

        internal decimal AveragePrice()
        {
            return priceBooks / countBooks;
        }
    }

    internal class Program
    {
        static void PrintTitle(Book book)
        {
            Console.WriteLine($"    {book.Title}");
        }

        static void AddBooks(BookDB bookDB)
        {
            bookDB.AddBook("The C Programming Language", "Brian W. Kernighan and Dennis M. Ritchie", 19.95m, true);
            bookDB.AddBook("The Unicode Standard 2.0", "The Unicode Consortium", 39.95m, true);
            bookDB.AddBook("The MS-DOS Encyclopedia", "Ray Duncan", 129.95m, false);
            bookDB.AddBook("Dogbert's Clues for the Clueless", "Scott Adams", 12.00m, true);
        }

        static void Main(string[] args)
        {
            BookDB bookDB = new BookDB();
            PriceToTaller totaller = new PriceToTaller();

            AddBooks(bookDB);
            Console.WriteLine("Paperback Book Titles: ");
            bookDB.ProcessPaperbackBooks(PrintTitle);

            bookDB.ProcessPaperbackBooks(totaller.AddBookToTotal);
            Console.WriteLine("Average Paperback Book Price: ${0:#.##}", totaller.AveragePrice());
        }
    }
}

