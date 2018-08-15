using LibraryofBooks.BLL.Services;
using LibraryofBooks.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryofBooks.Controllers
{
    public class NewspaperController : Controller
    {
        NewspaperService _newspaperService;

        public NewspaperController()
        {
            _newspaperService = new NewspaperService(new DAL.LibraryContext("DbConnect"));
        }

        public NewspaperController(NewspaperService serv)
        {
            _newspaperService = serv;
        }

        [Authorize(Roles = "admin, user")]
        public ActionResult Newspapers()
        {

            return View(_newspaperService.GetNewspapers());
        }
    }
}