using LibraryofBooks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryofBooks.ViewModels
{
    public class JournalViewModel
    {
        public int? Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

        public List<AuthorViewModel> Authors { get; set; }

        public List<PublishingHouseViewModel> PublishingHouses { get; set; }

        public JournalViewModel()
        {
            Authors = new List<AuthorViewModel>();
            PublishingHouses = new List<PublishingHouseViewModel>();
        }
    }
}
