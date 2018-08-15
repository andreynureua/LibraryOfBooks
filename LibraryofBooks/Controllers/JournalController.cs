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
    public class JournalController : Controller
    {

        JournalService _journalService;

        public JournalController()
        {
            _journalService = new JournalService(new DAL.LibraryContext("DbConnect"));
        }

        public JournalController(JournalService serv)
        {
            _journalService = serv;
        }

        [Authorize(Roles = "admin, user")]
        public ActionResult Journals()
        {
            return View(_journalService.GetJournals());
        }
    }
}