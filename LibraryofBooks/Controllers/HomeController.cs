using LibraryofBooks.BLL.Services;
using LibraryofBooks.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryofBooks.Controllers
{
    public class HomeController : Controller
    {
        BookService _bookService;
        PublishingHouseService _publishingHouseService;
        JournalService _journalService;
        NewspaperService _newspaperService;

        public HomeController()
        {
            _bookService = new BookService(new DAL.LibraryContext("DbConnect"));
            _publishingHouseService = new PublishingHouseService(new DAL.LibraryContext("DbConnect"));
            _journalService = new JournalService(new DAL.LibraryContext("DbConnect"));
            _newspaperService = new NewspaperService(new DAL.LibraryContext("DbConnect"));
        }

        [Authorize(Roles = "admin, user")]
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Search(string name)
        {
            return View();
        }

        public JsonResult Data(int id)
        {
            List<SearchViewModel> svm = new List<SearchViewModel>();
            PublishingHouseViewModel phvm = new PublishingHouseViewModel { Id = _publishingHouseService.Find(id).Id, Name = _publishingHouseService.Find(id).Name };
            List<BookViewModel> bvm = _bookService.GetBooks(phvm);
            List<JournalViewModel> jvm = _journalService.GetJournals(phvm);
            List<NewspaperViewModel> nvm = _newspaperService.GetNewspapers(phvm);

            svm.AddRange(bvm.Select(t => new SearchViewModel
            {
                Id = (int)t.Id,
                Type = "Book",
                Date = t.Date,
                Name = t.Name,
                Authors = t.Authors,
                PublishingHouses = t.PublishingHouses
            }));
            svm.AddRange(jvm.Select(t => new SearchViewModel
            {
                Id = (int)t.Id,
                Type = "Journal",
                Date = t.Date,
                Name = t.Name,
                Authors = t.Authors,
                PublishingHouses = t.PublishingHouses
            }));
            svm.AddRange(nvm.Select(t => new SearchViewModel
            {
                Id = (int)t.Id,
                Type = "Newspaper",
                Date = t.Date,
                Name = t.Name,
                Authors = t.Authors,
                PublishingHouses = t.PublishingHouses
            }));
            return Json(svm, JsonRequestBehavior.AllowGet);
        }

    }
}