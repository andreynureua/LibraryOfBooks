using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;
using LibraryofBooks.Entities;

namespace LibraryofBooks.ViewModels
{

    public class BookViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public List<AuthorViewModel> Authors { get; set; }

        public List<PublishingHouseViewModel> PublishingHouses { get; set; }

        public BookViewModel()
        {
            Authors = new List<AuthorViewModel>();
            PublishingHouses = new List<PublishingHouseViewModel>();
        }
    }
}