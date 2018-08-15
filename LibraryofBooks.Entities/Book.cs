using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace LibraryofBooks.Entities
{
    public class Book
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public DateTime Date { get; set; }

    }
}
