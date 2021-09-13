using Homework_2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_2
{
    public static class StaticListOfBooks
    {
        public static List<Book> Books = new List<Book>()
        {
            new Book(){ Title = "A time to kill", Author = "John Grisham" },
            new Book(){ Title = "The house of mirth", Author = "John Staiback" },
            new Book(){ Title = "East of Eden", Author = "Edith Wharton" },
            new Book(){ Title = "The sun also rises", Author = "Ernest Hemingway" },
            new Book(){ Title = "Vile bodies", Author = "Evelyn Waugh" },
            new Book(){ Title = "Number the stars", Author = "Lois Lowry" },
            new Book(){ Title = "As I lay dying", Author = "William Faulkner" }         
        };
    }
}
