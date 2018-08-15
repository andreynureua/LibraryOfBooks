using LibraryofBooks.BLL.Services;
using LibraryofBooks.Entities;
using LibraryofBooks.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryofBooks.Controllers
{
    public class AuthorController : Controller
    {

        AuthorService _authorService;

        public AuthorController()
        {
            _authorService = new AuthorService(new DAL.LibraryContext("DbConnect"));
        }

        public AuthorController(AuthorService serv)
        {
            _authorService = serv;
        }

        [Authorize(Roles = "admin, user")]
        public ActionResult Authors()
        {
            return View(_authorService.GetAuthors());
        }
    }
}