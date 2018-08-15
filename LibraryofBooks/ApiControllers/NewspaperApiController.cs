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
    public class NewspaperApiController : ApiController
    {
        NewspaperService _newspaperService;

        public NewspaperApiController()
        {
            _newspaperService = new NewspaperService(new DAL.LibraryContext("DbConnect"));
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult Data()
        {
            var data = _newspaperService.GetNewspapers();
            return Ok(data); 
        }

        [System.Web.Http.HttpGet]
        public void Create(string models)
        {
            List<NewspaperViewModel> _newspapers = JsonConvert.DeserializeObject<List<NewspaperViewModel>>(models);
            foreach (NewspaperViewModel nvm in _newspapers)
            {
                _newspaperService.AddNewspaper(nvm);
            }
        }

        [System.Web.Http.HttpGet]
        public void Delete(string models)
        {
            List<NewspaperViewModel> _newspapers = JsonConvert.DeserializeObject<List<NewspaperViewModel>>(models);
            foreach (NewspaperViewModel nvm in _newspapers)
            {
                _newspaperService.DeleteNewspaper((int)nvm.Id);
            }
        }

        [System.Web.Http.HttpGet]
        public void Update(string models)
        {
            List<NewspaperViewModel> _newspapers = JsonConvert.DeserializeObject<List<NewspaperViewModel>>(models);
            foreach (NewspaperViewModel nvm in _newspapers)
            {
                _newspaperService.UpdateNewspaper(nvm);
            }
        }

        protected override void Dispose(bool disposing)
        {
            _newspaperService.Dispose();
            base.Dispose(disposing);
        }
    }
}
