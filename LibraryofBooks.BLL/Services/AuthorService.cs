using LibraryofBookis.DAL.Repositories;
using LibraryofBooks.DAL;
using LibraryofBooks.DAL.Repositories;
using LibraryofBooks.Entities;
using LibraryofBooks.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace LibraryofBooks.BLL.Services
{
    public class AuthorService
    {
        private readonly AuthorRepository _authorRepository;

        public AuthorService(LibraryContext db)
        {
            _authorRepository = new AuthorRepository(db);
        }

        public void AddAuthor(AuthorViewModel avm)
        {
            Author author = new Author
            {
                Name = avm.Name,
                Surname = avm.Surname
            };
            _authorRepository.Create(author);
        }

        public List<AuthorViewModel> GetAuthors()
        {
            var authors = _authorRepository.GetAll().ToList();
            var res = authors.Select(b =>
            new AuthorViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Surname = b.Surname,
                FullName = b.Name + " " + b.Surname
            }).ToList();
            return res;
        }

        public void DeleteAuthor(int id)
        {
            _authorRepository.Delete(id);
        }

        public void UpdateAuthor(AuthorViewModel avm)
        {
            _authorRepository.Update(new Author { Id = (int)avm.Id, Name = avm.Name, Surname = avm.Surname });
        }

        public void Dispose()
        {
            _authorRepository.Dispose();
        }
    }
}
