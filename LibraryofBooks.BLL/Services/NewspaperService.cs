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
    public class NewspaperService 
    {
        private readonly NewspaperAuthorRepository _newspaperAuthorRepository;
        private readonly NewspaperPublishingHouseRepository _newspaperPublishingHouseRepository;
        private readonly AuthorRepository _authorRepository;
        private readonly PublishingHouseRepository _publishingHouseRepository;
        private readonly NewspaperRepository _newspaperRepository;

        public NewspaperService(LibraryContext db)
        {
            _newspaperAuthorRepository = new NewspaperAuthorRepository(db);
            _newspaperPublishingHouseRepository = new NewspaperPublishingHouseRepository(db);
            _authorRepository = new AuthorRepository(db);
            _publishingHouseRepository = new PublishingHouseRepository(db);
            _newspaperRepository = new NewspaperRepository(db);
        }

        public void AddNewspaper(NewspaperViewModel nvm)
        {
            int _id = _newspaperRepository.Create(new Newspaper
            {
                Name = nvm.Name,
                Date = nvm.Date,
            }).Id;
            List<NewspaperAuthor> _newspaperAuthors = nvm.Authors.Select(c => new NewspaperAuthor { NewspaperId = _id, AuthorId = (int)c.Id }).ToList();
            _newspaperAuthorRepository.AddRange(_newspaperAuthors);
            List<NewspaperPublishingHouse> _newspaperPublishingHouses = nvm.PublishingHouses.Select(c => new NewspaperPublishingHouse { NewspaperId = _id, PublishingHouseId = (int)c.Id }).ToList();
            _newspaperPublishingHouseRepository.AddRange(_newspaperPublishingHouses);
        }

        public List<NewspaperViewModel> GetNewspapers()
        {
            var a = _newspaperRepository.GetAll().ToList();
            var res = a.Select(b =>
            new NewspaperViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Date = b.Date,
                Authors = (from at in _authorRepository.GetAll().ToList()
                           from na in _newspaperAuthorRepository.GetAll().ToList()
                           where na.NewspaperId == b.Id
                           where na.AuthorId == at.Id
                           select new AuthorViewModel { Id = at.Id, FullName = at.Name + " " + at.Surname }).ToList(),
                PublishingHouses = (from ph in _publishingHouseRepository.GetAll().ToList()
                                    from bph in _newspaperPublishingHouseRepository.GetAll().ToList()
                                    where bph.NewspaperId == b.Id
                                    where bph.PublishingHouseId == ph.Id
                                    select new PublishingHouseViewModel { Id = ph.Id, Name = ph.Name }).ToList()
            }).ToList();
            return res;
        }

        public List<NewspaperViewModel> GetNewspapers(PublishingHouseViewModel phvm)
        {
            IEnumerable<int> newspaperId = _newspaperPublishingHouseRepository.GetAll().Where(h => h.PublishingHouseId == phvm.Id).Select(h => h.NewspaperId).ToList();
            var a = from b in _newspaperRepository.GetAll().ToList()
                    from t in newspaperId
                    where b.Id == t
                    select b;
            var res = a.Select(b =>
            new NewspaperViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Date = b.Date,
                Authors = (from at in _authorRepository.GetAll().ToList()
                           from na in _newspaperAuthorRepository.GetAll().ToList()
                           where na.NewspaperId == b.Id
                           where na.AuthorId == at.Id
                           select new AuthorViewModel { Id = at.Id, FullName = at.Name + " " + at.Surname }).ToList(),
                PublishingHouses = (from ph in _publishingHouseRepository.GetAll().ToList()
                                    from bph in _newspaperPublishingHouseRepository.GetAll().ToList()
                                    where bph.NewspaperId == b.Id
                                    where bph.PublishingHouseId == ph.Id
                                    select new PublishingHouseViewModel { Id = ph.Id, Name = ph.Name }).ToList()
            }).ToList();
            return res;
        }

        public void DeleteNewspaper(int id)
        {
            _newspaperRepository.Delete(id);
        }

        public void UpdateNewspaper(NewspaperViewModel nvm)
        {
            _newspaperRepository.Update(new Newspaper { Id = (int)nvm.Id, Name = nvm.Name, Date = nvm.Date });
            List<NewspaperAuthor> _newspaperAuthors = nvm.Authors.Select(c => new NewspaperAuthor { NewspaperId = (int)nvm.Id, AuthorId = (int)c.Id }).ToList();
            _newspaperAuthorRepository.RemoveRange(_newspaperAuthorRepository.GetAll().Where(a => a.NewspaperId == (int)nvm.Id).ToList());
            _newspaperAuthorRepository.AddRange(_newspaperAuthors);
            List<NewspaperPublishingHouse> _newspaperPublishingHouses = nvm.PublishingHouses.Select(c => new NewspaperPublishingHouse { NewspaperId = (int)nvm.Id, PublishingHouseId = (int)c.Id }).ToList();
            _newspaperPublishingHouseRepository.RemoveRange(_newspaperPublishingHouseRepository.GetAll().Where(a => a.NewspaperId == (int)nvm.Id).ToList());
            _newspaperPublishingHouseRepository.AddRange(_newspaperPublishingHouses);
        }

        public void Dispose()
        {
            _newspaperRepository.Dispose();
        }
    }
}

