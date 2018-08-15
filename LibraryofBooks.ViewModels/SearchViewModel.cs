using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryofBooks.ViewModels
{
    public class SearchViewModel
    {
        public int Id { get; set; }

        public string Type { get; set; }

        public string Name { get; set; }

        public List<AuthorViewModel> Authors { get; set; }

        public List<PublishingHouseViewModel> PublishingHouses { get; set; }

        public DateTime Date { get; set; }
    }
}
