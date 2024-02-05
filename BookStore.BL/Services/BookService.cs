using BookStore.BL.Interfaces;
using BookStore.DL.Repositories;
using BookStore.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BL.Services
{
    public class BookService : IBookService

    {
        private readonly IBookRepository _bookRepository;
        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }
        public List<Book>GetAllBooksByAuthor(int authorId)
        {
            return _bookRepository.GetAllBooksByAuthor(authorId);
        }
    }
}
