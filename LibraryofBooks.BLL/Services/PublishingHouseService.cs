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
    public class PublishingHouseService
    {
        private readonly PublishingHouseRepository _publishingHouseRepository;

        public PublishingHouseService(LibraryContext db)
        {
            _publishingHouseRepository = new PublishingHouseRepository(db);
        }

        public void AddPublishingHouse(PublishingHouseViewModel pvm)
        {
            PublishingHouse publishingHouse = new PublishingHouse
            {
                Name = pvm.Name,
            };
            _publishingHouseRepository.Create(publishingHouse);
        }

        public List<PublishingHouseViewModel> GetPublishingHouses()
        {
            var publishingHouses = _publishingHouseRepository.GetAll().ToList();
            var res = publishingHouses.Select(b =>
            new PublishingHouseViewModel
            {
                Id = b.Id,
                Name = b.Name,
            }).ToList();
            return res;
        }

        public void DeletePublishingHouse(int id)
        {
            _publishingHouseRepository.Delete(id);
        }

        public void UpdatePublishingHouse(PublishingHouseViewModel pvm)
        {
            _publishingHouseRepository.Update( new PublishingHouse { Id = (int)pvm.Id, Name = pvm.Name });
        }

        public PublishingHouse Find(int id)
        {
            return _publishingHouseRepository.Find(id);
        }

        public void Dispose()
        {
            _publishingHouseRepository.Dispose();
        }
    }
}
