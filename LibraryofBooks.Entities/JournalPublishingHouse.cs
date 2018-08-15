using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryofBooks.Entities
{
    public class JournalPublishingHouse
    {
        public int Id { get; set; }

        public virtual int JournalId { get; set; }

        [ForeignKey("JournalId")]
        public virtual Journal Journal { get; set; }

        [ForeignKey("PublishingHouseId")]
        public virtual PublishingHouse PublishingHouse { get; set; }

        public virtual int PublishingHouseId { get; set; }
    }
}
