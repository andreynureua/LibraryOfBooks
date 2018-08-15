using LibraryofBooks.DAL;
using LibraryofBooks.DAL.Repositories;
using LibraryofBooks.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryofBookis.DAL.Repositories
{
    public class AuthorRepository : Repository<Author>
    {
        public AuthorRepository(LibraryContext db) : base(db)
        {
        }
    }
}
