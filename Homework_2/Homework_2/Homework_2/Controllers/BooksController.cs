using Homework_2.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Homework_2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        [HttpGet]
        public ActionResult<List<Book>> GetAllBooks()
        {
            try
            {
                return StatusCode(StatusCodes.Status200OK, StaticListOfBooks.Books);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error has occured");
            }
        }

        [HttpGet("index")]     //api/books/index?id=2
        public ActionResult<Book> GetBookById(int id)
        {
            try
            {
                if (id < 0)
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "Please enter a valid number.");
                }

                if (id >= StaticListOfBooks.Books.Count)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "There is no book with that ID.");
                }
                return StatusCode(StatusCodes.Status200OK, StaticListOfBooks.Books[id]);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error has occured");
            }

        }

        [HttpGet("filter")]
        public ActionResult<List<Book>> FilterBooks(string title, string author) //returns list in case there are multiple books by the same author
        {
            try
            {
                if (string.IsNullOrEmpty(title) && string.IsNullOrEmpty(author))
                {
                    return StatusCode(StatusCodes.Status400BadRequest, "You HAVE TO enter Title or Author of the book!");
                }
                if (string.IsNullOrEmpty(title))
                {
                    List<Book> filteredByAuthor = StaticListOfBooks.Books.Where(x => x.Author.ToLower().Contains(author.ToLower())).ToList();
                    return StatusCode(StatusCodes.Status200OK, filteredByAuthor);
                }
                if (string.IsNullOrEmpty(author))
                {
                    List<Book> filteredByBook = StaticListOfBooks.Books.Where(x => x.Title.ToLower().Contains(title.ToLower())).ToList();
                    return StatusCode(StatusCodes.Status200OK, filteredByBook);
                }
                List<Book> filteredAll = StaticListOfBooks.Books.Where(x => x.Title.ToLower().Contains(title.ToLower()) && x.Author.ToLower().Contains(author.ToLower())).ToList();
                return Ok(filteredAll);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error has occured");
            }
        }

        [HttpPost("post")]
        public IActionResult AddNewBook([FromBody] Book book)
        {
            try
            {
                StaticListOfBooks.Books.Add(book);
                return StatusCode(StatusCodes.Status201Created, "New book is added to the list!");
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error has occured");
            }
        }
        [HttpPost("postTitles")]
        public IActionResult GetTitles([FromBody] List<Book> books)
        {
            try
            {
                List<string> bookTitles = new List<string>();
                foreach(Book book in books)
                {                  
                    bookTitles.Add(book.Title);
                }
                return StatusCode(StatusCodes.Status200OK, bookTitles);

            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Server error has occured");
            }
        }
    }
}
