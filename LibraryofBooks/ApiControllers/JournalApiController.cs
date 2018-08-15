using LibraryofBooks.BLL.Services;
using LibraryofBooks.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace LibraryofBooks.ApiControllers
{
    public class JournalApiController : ApiController
    {
        JournalService _journalService;

        public JournalApiController()
        {
            _journalService = new JournalService(new DAL.LibraryContext("DbConnect"));
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult Data()
        {
            var data = _journalService.GetJournals();
            return Ok(data);
        }

        protected override void Dispose(bool disposing)
        {
            _journalService.Dispose();
            base.Dispose(disposing);
        }

        [System.Web.Http.HttpGet]
        public void Create(string models)
        {
            List<JournalViewModel> journals = JsonConvert.DeserializeObject<List<JournalViewModel>>(models);
            foreach (JournalViewModel jvm in journals)
            {
                _journalService.AddJournal(jvm);
            }
        }

        [System.Web.Http.HttpGet]
        public void Delete(string models)
        {
            List<JournalViewModel> journals = JsonConvert.DeserializeObject<List<JournalViewModel>>(models);
            foreach (JournalViewModel jvm in journals)
            {
                _journalService.DeleteJournal((int)jvm.Id);
            }
        }

        [System.Web.Http.HttpGet]
        public void Update(string models)
        {
            List<JournalViewModel> books = JsonConvert.DeserializeObject<List<JournalViewModel>>(models);
            foreach (JournalViewModel jvm in books)
            {
                _journalService.UpdateJournal(jvm);
            }
        }
    }
}
