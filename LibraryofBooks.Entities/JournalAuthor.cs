using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryofBooks.Entities
{
    public class JournalAuthor
    {
        public int Id { get; set; }

        public virtual int JournalId { get; set; }

        [ForeignKey("JournalId")]
        public virtual Journal Journal { get; set; }

        [ForeignKey("AuthorId")]
        public virtual Author Author { get; set; }

        public virtual int AuthorId { get; set; }
    }
}
