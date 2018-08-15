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
    public class PublishingHouseApiController : ApiController
    {
        PublishingHouseService _publishingHouseService;

        public PublishingHouseApiController()
        {
            _publishingHouseService = new PublishingHouseService(new DAL.LibraryContext("DbConnect"));
        }

        protected override void Dispose(bool disposing)
        {
            _publishingHouseService.Dispose();
            base.Dispose(disposing);
        }

        [System.Web.Http.HttpGet]
        public IHttpActionResult Data()
        {
            var data = _publishingHouseService.GetPublishingHouses();
            return Ok(data);
        }

        [System.Web.Http.HttpGet]
        public void Create(string models)
        {
            List<PublishingHouseViewModel> publishingHouses = JsonConvert.DeserializeObject<List<PublishingHouseViewModel>>(models);
            foreach (PublishingHouseViewModel pvm in publishingHouses)
            {
                _publishingHouseService.AddPublishingHouse(new PublishingHouseViewModel { Name = pvm.Name });
            }
        }

        [System.Web.Http.HttpGet]
        public void Delete(string models)
        {
            List<PublishingHouseViewModel> publishingHouses = JsonConvert.DeserializeObject<List<PublishingHouseViewModel>>(models);
            foreach (PublishingHouseViewModel publishingHouse in publishingHouses)
            {
                _publishingHouseService.DeletePublishingHouse((int)publishingHouse.Id);
            }
        }

        [System.Web.Http.HttpGet]
        public void Update(string models)
        {
            List<PublishingHouseViewModel> publishingHouses = JsonConvert.DeserializeObject<List<PublishingHouseViewModel>>(models);
            foreach (PublishingHouseViewModel pvm in publishingHouses)
            {
                _publishingHouseService.UpdatePublishingHouse(pvm);
            }
        }
    }
}
