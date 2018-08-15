using LibraryofBooks.BLL.Services;
using LibraryofBooks.Entities;
using LibraryofBooks.ViewModels;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LibraryofBooks.Controllers
{
    public class PublishingHouseController : Controller
    {
        PublishingHouseService _publishingHouseService;

        public PublishingHouseController()
        {
            _publishingHouseService = new PublishingHouseService(new DAL.LibraryContext("DbConnect"));
        }

        public PublishingHouseController(PublishingHouseService serv)
        {
            _publishingHouseService = serv;
        }

        [Authorize(Roles = "admin, user")]
        public ActionResult PublishingHouses()
        {
            return View(_publishingHouseService.GetPublishingHouses());
        }

    }
}