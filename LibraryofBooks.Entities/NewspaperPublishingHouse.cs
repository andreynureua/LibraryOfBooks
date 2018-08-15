using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryofBooks.Entities
{
    public class NewspaperPublishingHouse
    {
        public int Id { get; set; }

        public virtual int NewspaperId { get; set; }

        [ForeignKey("NewspaperId")]
        public virtual Newspaper Newspaper { get; set; }

        [ForeignKey("PublishingHouseId")]
        public virtual PublishingHouse PublishingHouse { get; set; }

        public virtual int PublishingHouseId { get; set; }
    }
}
