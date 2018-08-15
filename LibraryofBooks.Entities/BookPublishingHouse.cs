using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryofBooks.Entities
{
    public class BookPublishingHouse
    {
        public int Id { get; set; }

        public virtual int BookId { get; set; }

        [ForeignKey("BookId")]
        public virtual Book Book { get; set; }

        [ForeignKey("PublishingHouseId")]
        public virtual PublishingHouse PublishingHouse { get; set; }

        public virtual int PublishingHouseId { get; set; }
    }
}
