using BookStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.DL.Repositories
{
    public interface IBookRepository
    {
        List<Book> GetAllBooksByAuthor(int authorId);

      //  Book? GetByTitle(string title);
    }
}
