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
    public class AuthorApiController : ApiController
    {
        AuthorService _authorService;

        public AuthorApiController()
        {
            _authorService = new AuthorService(new DAL.LibraryContext("DbConnect"));
        }

        protected override void Dispose(bool disposing)
        {
            _authorService.Dispose();
            base.Dispose(disposing);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult Data()
        {
            var data = _authorService.GetAuthors();
            return Ok(data);
        }

        [System.Web.Http.HttpGet]
        public void Create(string models)
        {
            List<AuthorViewModel> authors = JsonConvert.DeserializeObject<List<AuthorViewModel>>(models);
            foreach (AuthorViewModel avm in authors)
            {
                _authorService.AddAuthor(new AuthorViewModel { Name = avm.Name, Surname = avm.Surname });
            }
        }

        [System.Web.Http.HttpGet]
        public void Delete(string models)
        {
            List<AuthorViewModel> authors = JsonConvert.DeserializeObject<List<AuthorViewModel>>(models);
            foreach (AuthorViewModel author in authors)
            {
                _authorService.DeleteAuthor((int)author.Id);
            }
        }

        [System.Web.Http.HttpGet]
        public void Update(string models)
        {
            List<AuthorViewModel> authors = JsonConvert.DeserializeObject<List<AuthorViewModel>>(models);
            foreach (AuthorViewModel avm in authors)
            {
                _authorService.UpdateAuthor(avm);
            }
        }
    }
}
