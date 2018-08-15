using LibraryofBooks.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryofBooks.DAL
{
    public class LibraryContext : DbContext
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Journal> Journals { get; set; }
        public DbSet<Newspaper> Newspapers { get; set; }
        public DbSet<BookAuthor> BookAuthors { get; set; }
        public DbSet<JournalAuthor> JournalAuthors { get; set; }
        public DbSet<NewspaperAuthor> NewspaperAuthors { get; set; }
        public DbSet<PublishingHouse> PublishingHouses { get; set; }
        public DbSet<BookPublishingHouse> BookPublishingHouses { get; set; }
        public DbSet<JournalPublishingHouse> JournalPublishingHouses { get; set; }
        public DbSet<NewspaperPublishingHouse> NewspaperPublishingHouses { get; set; }

        static LibraryContext ()
        {
            Database.SetInitializer(new StoreDbInitializer());
        }

        public LibraryContext(string connectionString)
            : base(connectionString)
        {
        }

        public LibraryContext()
            : base("DbConnect")
        {
        }

    }
    public class StoreDbInitializer : DropCreateDatabaseIfModelChanges<LibraryContext>
    {
        protected override void Seed(LibraryContext db)
        {
            Author at1 = new Author { Name = "Ray", Surname = "Bradbury" };
            Author at2 = new Author { Name = "Ivan", Surname = "Turgenev" };
            db.Authors.AddRange(new List<Author> { at1, at2 });
            Book b1 = new Book { Name = "Война и мир", Date = new DateTime(1876, 5, 7) };
            Book b2 = new Book { Name = "Отцы и дети", Date = new DateTime(1956, 3, 9) };
            Book b3 = new Book { Name = "Огни", Date = new DateTime(1872, 7, 12) };
            db.Books.AddRange(new List<Book> { b1, b2, b3 });
            db.SaveChanges();
            BookAuthor ba1 = new BookAuthor { BookId = b1.Id, AuthorId = at1.Id };
            BookAuthor ba2 = new BookAuthor { BookId = b2.Id, AuthorId = at1.Id };
            BookAuthor ba3 = new BookAuthor { BookId = b2.Id, AuthorId = at2.Id };
            BookAuthor ba4 = new BookAuthor { BookId = b3.Id, AuthorId = at2.Id };
            db.BookAuthors.AddRange(new List<BookAuthor> { ba1, ba2, ba3, ba4 });
            db.SaveChanges();
            Journal j1 = new Journal { Name = "National Gerografic", Date = new DateTime(1972, 2, 11) };
            Journal j2 = new Journal { Name = "Nature", Date = new DateTime(1982, 8, 3) };
            Journal j3 = new Journal { Name = "Writers", Date = new DateTime(1962, 6, 10) };
            Journal j4 = new Journal { Name = "Books", Date = new DateTime(1982, 5, 8) };
            db.Journals.AddRange(new List<Journal> { j1, j2, j3, j4 });
            db.SaveChanges();
            JournalAuthor ja1 = new JournalAuthor { JournalId = j1.Id, AuthorId = at1.Id };
            JournalAuthor ja2 = new JournalAuthor { JournalId = j2.Id, AuthorId = at1.Id };
            JournalAuthor ja3 = new JournalAuthor { JournalId = j4.Id, AuthorId = at2.Id };
            JournalAuthor ja4 = new JournalAuthor { JournalId = j3.Id, AuthorId = at1.Id };
            JournalAuthor ja5 = new JournalAuthor { JournalId = j3.Id, AuthorId = at2.Id };
            db.JournalAuthors.AddRange(new List<JournalAuthor> { ja1, ja2, ja3, ja4, ja5 });
            db.SaveChanges();
            Newspaper np1 = new Newspaper { Name = "The Times", Date = new DateTime(2002, 1, 9) };
            Newspaper np2 = new Newspaper { Name = "The London", Date = new DateTime(2005, 2, 11) };
            Newspaper np3 = new Newspaper { Name = "Daily News", Date = new DateTime(2001, 5, 8) };
            db.Newspapers.AddRange(new List<Newspaper> { np1, np2, np3 });
            db.SaveChanges();
            NewspaperAuthor na1 = new NewspaperAuthor { NewspaperId = np1.Id, AuthorId = at1.Id };
            NewspaperAuthor na2 = new NewspaperAuthor { NewspaperId = np1.Id, AuthorId = at2.Id };
            NewspaperAuthor na3 = new NewspaperAuthor { NewspaperId = np2.Id, AuthorId = at1.Id };
            NewspaperAuthor na4 = new NewspaperAuthor { NewspaperId = np3.Id, AuthorId = at2.Id };
            db.NewspaperAuthors.AddRange(new List<NewspaperAuthor> { na1, na2, na3, na4 });
            db.SaveChanges();
            PublishingHouse pb1 = new PublishingHouse { Name = "Kiev", };
            PublishingHouse pb2 = new PublishingHouse { Name = "Kharkov" };
            PublishingHouse pb3 = new PublishingHouse { Name = "London" };
            db.PublishingHouses.AddRange(new List<PublishingHouse> { pb1, pb2, pb3});
            db.SaveChanges();
            BookPublishingHouse bph1 = new BookPublishingHouse { BookId = b1.Id, PublishingHouseId = pb1.Id };
            BookPublishingHouse bph2 = new BookPublishingHouse { BookId = b1.Id, PublishingHouseId = pb2.Id };
            BookPublishingHouse bph3 = new BookPublishingHouse { BookId = b2.Id, PublishingHouseId = pb1.Id };
            BookPublishingHouse bph4 = new BookPublishingHouse { BookId = b2.Id, PublishingHouseId = pb2.Id };
            BookPublishingHouse bph5 = new BookPublishingHouse { BookId = b2.Id, PublishingHouseId = pb3.Id };
            BookPublishingHouse bph6 = new BookPublishingHouse { BookId = b3.Id, PublishingHouseId = pb2.Id };
            BookPublishingHouse bph7 = new BookPublishingHouse { BookId = b3.Id, PublishingHouseId = pb3.Id };
            db.BookPublishingHouses.AddRange(new List<BookPublishingHouse> { bph1, bph2, bph3, bph4, bph5, bph6, bph7});
            db.SaveChanges();
            JournalPublishingHouse jph1 = new JournalPublishingHouse { JournalId = j1.Id, PublishingHouseId = pb1.Id };
            JournalPublishingHouse jph2 = new JournalPublishingHouse { JournalId = j1.Id, PublishingHouseId = pb2.Id };
            JournalPublishingHouse jph3 = new JournalPublishingHouse { JournalId = j2.Id, PublishingHouseId = pb2.Id };
            JournalPublishingHouse jph4 = new JournalPublishingHouse { JournalId = j2.Id, PublishingHouseId = pb3.Id };
            JournalPublishingHouse jph5 = new JournalPublishingHouse { JournalId = j3.Id, PublishingHouseId = pb3.Id };
            JournalPublishingHouse jph6 = new JournalPublishingHouse { JournalId = j4.Id, PublishingHouseId = pb1.Id };
            JournalPublishingHouse jph7 = new JournalPublishingHouse { JournalId = j4.Id, PublishingHouseId = pb3.Id };
            db.JournalPublishingHouses.AddRange(new List<JournalPublishingHouse> { jph1, jph2, jph3, jph4, jph5, jph6, jph7 });
            db.SaveChanges();
            NewspaperPublishingHouse nph1 = new NewspaperPublishingHouse { NewspaperId = np1.Id, PublishingHouseId = pb1.Id };
            NewspaperPublishingHouse nph2 = new NewspaperPublishingHouse { NewspaperId = np1.Id, PublishingHouseId = pb2.Id };
            NewspaperPublishingHouse nph3 = new NewspaperPublishingHouse { NewspaperId = np2.Id, PublishingHouseId = pb1.Id };
            NewspaperPublishingHouse nph4 = new NewspaperPublishingHouse { NewspaperId = np2.Id, PublishingHouseId = pb2.Id };
            NewspaperPublishingHouse nph5 = new NewspaperPublishingHouse { NewspaperId = np3.Id, PublishingHouseId = pb1.Id };
            NewspaperPublishingHouse nph6 = new NewspaperPublishingHouse { NewspaperId = np3.Id, PublishingHouseId = pb2.Id };
            NewspaperPublishingHouse nph7 = new NewspaperPublishingHouse { NewspaperId = np3.Id, PublishingHouseId = pb3.Id };
            db.NewspaperPublishingHouses.AddRange(new List<NewspaperPublishingHouse> { nph1, nph2, nph3, nph4, nph5, nph6, nph7 });
            db.SaveChanges();
        }                                                        
    }                                                            
}                                                                
