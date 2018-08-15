using LibraryofBooks.BLL.Services;
using LibraryofBooks.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;

namespace LibraryofBooks.ApiControllers
{
    public class BookApiController : ApiController
    {
        BookService _bookService;

        public BookApiController()
        {
            _bookService = new BookService(new DAL.LibraryContext("DbConnect"));
        }

        [HttpGet]
        public IHttpActionResult Data()
        {
            var data = _bookService.GetBooks();
            return Ok(data);
        }

        [HttpGet]
        public void Create(string models)
        {
            List<BookViewModel> books = JsonConvert.DeserializeObject<List<BookViewModel>>(models);
            foreach (BookViewModel bvm in books)
            {
                _bookService.AddBook(bvm);
            }
        }

        [HttpGet]
        public void Delete(string models)
        {
            List<BookViewModel> books = JsonConvert.DeserializeObject<List<BookViewModel>>(models);
            foreach (BookViewModel bm in books)
            {
                _bookService.DeleteBook((int)bm.Id);
            }
        }

        [HttpGet]
        public void Update(string models)
        {
            List<BookViewModel> books = JsonConvert.DeserializeObject<List<BookViewModel>>(models);
            foreach (BookViewModel bvm in books)
            {
                _bookService.UpdateBook(bvm);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _bookService.Dispose();
            base.Dispose(disposing);
        }
    }
}
