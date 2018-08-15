using System;
using LibraryofBooks.BLL.Infrastructure;
using LibraryofBooks.BLL.Interfaces;
using System.Collections.Generic;
using LibraryofBooks.Entities;
using AutoMapper;
using LibraryofBooks.DAL.Interfaces;
using LibraryofBooks.ViewModels;
using LibraryofBooks.DAL.Repositories;
using LibraryofBooks.DAL;
using System.Linq;
using System.Data.Entity;
using System.Runtime.Serialization.Json;
using System.IO;
using Newtonsoft.Json;
using LibraryofBookis.DAL.Repositories;

namespace LibraryofBooks.BLL.Services
{
    public class BookService 
    {
        private readonly BookAuthorRepository _bookAuthorRepository;
        private readonly BookPublishingHouseRepository _bookPublishingHouseRepository;
        private readonly AuthorRepository _authorRepository;
        private readonly PublishingHouseRepository _publishingHouseRepository;
        private readonly BookRepository _bookRepository;

        public BookService(LibraryContext db)
        {
            _bookAuthorRepository = new BookAuthorRepository(db);
            _bookPublishingHouseRepository = new BookPublishingHouseRepository(db);
            _authorRepository = new AuthorRepository(db);
            _publishingHouseRepository = new PublishingHouseRepository(db);
            _bookRepository = new BookRepository(db);
        }

        public void AddBook(BookViewModel bvm)
        {
            int _id = _bookRepository.Create(new Book
            {
                Name = bvm.Name,
                Date = bvm.Date,
            }).Id;
            List<BookAuthor> _bookAuthors = bvm.Authors.Select(c => new BookAuthor { BookId = _id, AuthorId = (int)c.Id }).ToList();
            _bookAuthorRepository.AddRange(_bookAuthors);
            List<BookPublishingHouse> _bookPublishingHouses = bvm.PublishingHouses.Select(c => new BookPublishingHouse { BookId = _id, PublishingHouseId = (int)c.Id }).ToList();
            _bookPublishingHouseRepository.AddRange(_bookPublishingHouses);
        }

        public List<BookViewModel> GetBooks()
        {
            var a = _bookRepository.GetAll().ToList();
            var res = a.Select(b =>
            new BookViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Date = b.Date,
                Authors = (from at in _authorRepository.GetAll().ToList()
                           from ba in _bookAuthorRepository.GetAll().ToList()
                           where ba.BookId == b.Id
                           where ba.AuthorId == at.Id
                           select new AuthorViewModel { Id = at.Id, FullName = at.Name + " " + at.Surname }).ToList(),
                PublishingHouses = (from ph in _publishingHouseRepository.GetAll().ToList()
                                    from bph in _bookPublishingHouseRepository.GetAll().ToList()
                                    where bph.BookId == b.Id
                                    where bph.PublishingHouseId == ph.Id
                                    select new PublishingHouseViewModel { Id = ph.Id, Name = ph.Name }).ToList()

            }).ToList();
            return res;
        }

        public List<BookViewModel> GetBooks(PublishingHouseViewModel phvm)
        {
            IEnumerable<int> booksId = _bookPublishingHouseRepository.GetAll().Where(h => h.PublishingHouseId == phvm.Id).Select(h => h.BookId).ToList();
            var a = from b in _bookRepository.GetAll().ToList()
                    from t in booksId
                    where b.Id == t
                    select b;
            var res = a.Select(b =>
            new BookViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Date = b.Date,
                Authors = (from at in _authorRepository.GetAll().ToList()
                           from ba in _bookAuthorRepository.GetAll().ToList()
                           where ba.BookId == b.Id
                           where ba.AuthorId == at.Id
                           select new AuthorViewModel { Id = at.Id, FullName = at.Name + " " + at.Surname }).ToList(),
                PublishingHouses = (from ph in _publishingHouseRepository.GetAll().ToList()
                                    from bph in _bookPublishingHouseRepository.GetAll().ToList()
                                    where bph.BookId == b.Id
                                    where bph.PublishingHouseId == ph.Id
                                    select new PublishingHouseViewModel { Id = ph.Id, Name = ph.Name }).ToList()

            }).ToList();
            return res;
        }

        public void DeleteBook(int id)
        {
            _bookRepository.Delete(id);
        }

        public void UpdateBook(BookViewModel bvm)
        {
            _bookRepository.Update(new Book { Id = (int)bvm.Id, Name = bvm.Name, Date = bvm.Date });
            List<BookAuthor> _bookAuthors = bvm.Authors.Select(c => new BookAuthor { BookId = (int)bvm.Id, AuthorId = (int)c.Id }).ToList();
            _bookAuthorRepository.RemoveRange(_bookAuthorRepository.GetAll().Where(a => a.BookId == (int)bvm.Id).ToList());
            _bookAuthorRepository.AddRange(_bookAuthors);
            List<BookPublishingHouse> _bookPublishingHouses = bvm.PublishingHouses.Select(c => new BookPublishingHouse { BookId = (int)bvm.Id, PublishingHouseId = (int)c.Id }).ToList();
            _bookPublishingHouseRepository.RemoveRange(_bookPublishingHouseRepository.GetAll().Where(a => a.BookId == (int)bvm.Id).ToList());
            _bookPublishingHouseRepository.AddRange(_bookPublishingHouses);
        }

        public void Dispose()
        {
            _bookRepository.Dispose();
        }
    }
}

