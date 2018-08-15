using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using LibraryofBooks.BLL.Interfaces;
using LibraryofBooks.BLL.Services;
using LibraryofBooks.ViewModels;
using LibraryofBooks.Entities;
using System.Web.Helpers;
using Newtonsoft.Json;
using System.Runtime.Serialization;

namespace LibraryofBooks.Controllers
{
 
    public class BookController : Controller
    {
        BookService _bookService;

        public BookController()
        {
            _bookService = new BookService(new DAL.LibraryContext("DbConnect"));
        }

        public BookController(BookService serv)
        {
            _bookService = serv;
        }

        [Authorize(Roles = "admin, user")]
        public ActionResult Books()
        {  
            return View(_bookService.GetBooks());
        }
    }
}