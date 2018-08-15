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
    public class JournalService
    {
        private readonly JournalAuthorRepository _journalAuthorRepository;
        private readonly JournalPublishingHouseRepository _journalPublishingHouseRepository;
        private readonly AuthorRepository _authorRepository;
        private readonly PublishingHouseRepository _publishingHouseRepository;
        private readonly JournalRepository _journalRepository;

        public JournalService(LibraryContext db)
        {
            _journalAuthorRepository = new JournalAuthorRepository(db);
            _journalPublishingHouseRepository = new JournalPublishingHouseRepository(db);
            _authorRepository = new AuthorRepository(db);
            _publishingHouseRepository = new PublishingHouseRepository(db);
            _journalRepository = new JournalRepository(db);
        }

        public void AddJournal(JournalViewModel jvm)
        {
            int _id = _journalRepository.Create(new Journal
            {
                Name = jvm.Name,
                Date = jvm.Date,
            }).Id;
            List<JournalAuthor> _journalAuthors = jvm.Authors.Select(c=> new JournalAuthor { JournalId = _id, AuthorId = (int)c.Id }).ToList();
            _journalAuthorRepository.AddRange(_journalAuthors);
            List<JournalPublishingHouse> _journalPublishingHouses = jvm.PublishingHouses.Select(c => new JournalPublishingHouse { JournalId = _id, PublishingHouseId = (int)c.Id }).ToList();
            _journalPublishingHouseRepository.AddRange(_journalPublishingHouses);
        }

        public List<JournalViewModel> GetJournals()
        {
            var a = _journalRepository.GetAll().ToList();
            var res = a.Select(b =>
            new JournalViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Date = b.Date,
                Authors = (from at in _authorRepository.GetAll().ToList()
                           from ba in _journalAuthorRepository.GetAll().ToList()
                           where ba.JournalId == b.Id
                           where ba.AuthorId == at.Id
                           select new AuthorViewModel { Id = at.Id, FullName = at.Name + " " + at.Surname }).ToList(),
                PublishingHouses = (from ph in _publishingHouseRepository.GetAll().ToList()
                                    from bph in _journalPublishingHouseRepository.GetAll().ToList()
                                    where bph.JournalId == b.Id
                                    where bph.PublishingHouseId == ph.Id
                                    select new PublishingHouseViewModel { Id = ph.Id, Name = ph.Name }).ToList()
            }).ToList();
            return res;
        }

        public List<JournalViewModel> GetJournals(PublishingHouseViewModel phvm)
        {
            IEnumerable<int> journalsId = _journalPublishingHouseRepository.GetAll().Where(h => h.PublishingHouseId == phvm.Id).Select(h => h.JournalId).ToList();
            var a = from b in _journalRepository.GetAll().ToList()
                    from t in journalsId
                    where b.Id == t
                    select b;
            var res = a.Select(b =>
            new JournalViewModel
            {
                Id = b.Id,
                Name = b.Name,
                Date = b.Date,
                Authors = (from at in _authorRepository.GetAll().ToList()
                           from ba in _journalAuthorRepository.GetAll().ToList()
                           where ba.JournalId == b.Id
                           where ba.AuthorId == at.Id
                           select new AuthorViewModel { Id = at.Id, FullName = at.Name + " " + at.Surname }).ToList(),
                PublishingHouses = (from ph in _publishingHouseRepository.GetAll().ToList()
                                    from bph in _journalPublishingHouseRepository.GetAll().ToList()
                                    where bph.JournalId == b.Id
                                    where bph.PublishingHouseId == ph.Id  
                                    select new PublishingHouseViewModel { Id = ph.Id, Name = ph.Name }).ToList()
            }).ToList();
            return res;
        }

        public void DeleteJournal(int id)
        {
            _journalRepository.Delete(id);
        }

        public void UpdateJournal(JournalViewModel jvm)
        {
            _journalRepository.Update(new Journal { Id = (int)jvm.Id, Name = jvm.Name, Date = jvm.Date });
            List<JournalAuthor> _journalAuthors = jvm.Authors.Select(c => new JournalAuthor { JournalId = (int)jvm.Id, AuthorId = (int)c.Id }).ToList();
            _journalAuthorRepository.RemoveRange(_journalAuthorRepository.GetAll().Where(a => a.JournalId == (int)jvm.Id).ToList());
            _journalAuthorRepository.AddRange(_journalAuthors);
            List<JournalPublishingHouse> _journalPublishingHouses = jvm.PublishingHouses.Select(c => new JournalPublishingHouse { JournalId = (int)jvm.Id, PublishingHouseId = (int)c.Id }).ToList();
            _journalPublishingHouseRepository.RemoveRange(_journalPublishingHouseRepository.GetAll().Where(a => a.JournalId == (int)jvm.Id).ToList());
            _journalPublishingHouseRepository.AddRange(_journalPublishingHouses);
        }

        public void Dispose()
        {
            _journalRepository.Dispose();
        }
    }
}
