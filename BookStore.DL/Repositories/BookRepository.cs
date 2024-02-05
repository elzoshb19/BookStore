using BookStore.DL.MemoryDB;
using BookStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DL.Repositories
{
    public class BookRepository : IBookRepository
    {
        public List<Book> GetAllBooksByAuthor(int authorId)
        {
            var result = InMemoryDB.BookData.Where(b => b.AuthorID == authorId).ToList();
            return result;
        }
    }
}
