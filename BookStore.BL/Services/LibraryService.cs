using BookStore.BL.Interfaces;
using BookStore.Models.Models;
using BookStore.Models.Responses;
using BookStore.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookStore.BL.Services
{
    public class LibraryService : ILibraryService
    {
        private readonly IBookService _bookService;
        private readonly IAuthorService _authorService;

        public LibraryService(IAuthorService authorService, 
                                IBookService bookService)
        {
            _authorService = authorService;
            _bookService = bookService;
        }

        public Author? Author { get; private set; }
        public List<Book>? Books { get; private set; }

        public GetAllBooksByAuthorResponse? GetAllBooksByAuthor(GetAllBooksByAuthorRequest request)
        {
            throw new NotImplementedException();
        }

        public GetAllBooksByAuthorResponse? GetAllBooksByAuthorAfterDate(GetAllBooksByAuthorRequest request)
        {
            var books = _bookService.GetAllBooksByAuthor(request.AuthorId);
            var author = _authorService.GetById(request.AuthorId);
            var result = new GetAllBooksByAuthorResponse();

            Author = author;
            Books = books.Where(b => b.ReleaseDate >= request.AfterDate).ToList();

            return result;
        }
        }
    }
