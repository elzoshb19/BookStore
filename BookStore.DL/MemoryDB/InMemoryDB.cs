using BookStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DL.MemoryDB
{
    public static class InMemoryDB
    {
        public static List<Book> BookData = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                AuthorID = 1,
                ReleaseDate = new DateTime(2005,02,12),
                Title = "Book 1"
            },
            new Book()
            {
                Id = 2,
                AuthorID = 2,
                ReleaseDate = new DateTime(2007,02,12),
                Title = "Book 2"
            }
        };
        public static List<Author> AuthorData = new List<Author>()
        {
            new Author()
            {
                Id = 1,
                Name = "Author 1",
                BirthDay = DateTime.Now
            },
            new Author()
            {
                Id = 2,
                Name = "Author 2",
                BirthDay = DateTime.Now
            },
            new Author()
            {
                Id = 3,
                Name = "Author 3",
                BirthDay = DateTime.Now
            }
        };
    }
}
