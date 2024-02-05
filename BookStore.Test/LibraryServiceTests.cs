using BookStore.BL.Services;
using BookStore.DL.Interfaces;
using BookStore.DL.Repositories;
using BookStore.Models.Models;
using BookStore.Models.Requests;

using Moq;

namespace BookStore.Tests
{
    public class LibraryServiceTests
    {
        public static List<Book> BookData = new List<Book>()
        {
            new Book()
            {
                Id = 1,
                AuthorID = 1,
                ReleaseDate = new DateTime(2005,02, 12),
                Title = "Book 1"
            },
            new Book()
            {
                Id = 2,
                AuthorID = 1,
                ReleaseDate = new DateTime(2007,02, 12),
                Title = "Book 2"
            }
        };

        public static List<Author> AuthorData =
            new List<Author>()
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
        [Fact]
        public void GetAllBooksCount_OK()
        {
            //setup
            var input = 10;
            var authorId = 1;
            var expectedCount = 12;

            var mockedBookRepository =
                new Mock<IBookRepository>();
            var mockedAuthorRepository =
                new Mock<IAuthorRepository>();

            mockedBookRepository.Setup(
                x =>
                    x.GetAllBooksByAuthor(authorId))
                .Returns(BookData.Where(b =>
                    b.AuthorID == authorId).ToList());

            //inject
            var bookService =
                new BookService(mockedBookRepository.Object);
            var authorService =
                new AuthorService(mockedAuthorRepository.Object);
            var libraryService =
                new LibraryService(bookService, authorService);

            //act
            var result =
                libraryService.GetAllBooksCount(input, authorId);

            //Assert
            Assert.Equal(expectedCount, result);
        }

        [Fact]
        public void GetAllBooksCount_WrongAuthorId()
        {
            //setup
            var input = 10;
            var authorId = 111;
            var expectedCount = 10;

            var mockedBookRepository =
                new Mock<IBookRepository>();
            var mockedAuthorRepository =
                new Mock<IAuthorRepository>();

            mockedBookRepository.Setup(
                    x =>
                        x.GetAllBooksByAuthor(authorId))
                .Returns(BookData.Where(b =>
                    b.AuthorID == authorId).ToList());

            //inject
            var bookService =
                new BookService(mockedBookRepository.Object);
            var authorService =
                new AuthorService(mockedAuthorRepository.Object);
            var libraryService =
                new LibraryService(bookService, authorService);

            //act
            var result =
                libraryService.GetAllBooksCount(input, authorId);

            //Assert
            Assert.Equal(expectedCount, result);
        }

        [Fact]
        public void GetAllBooksCount_NegativeInput()
        {
            //setup
            var input = -10;
            var authorId = 111;
            var expectedCount = 0;

            var mockedBookRepository =
                new Mock<IBookRepository>();
            var mockedAuthorRepository =
                new Mock<IAuthorRepository>();

            mockedBookRepository.Setup(
                    x =>
                        x.GetAllBooksByAuthor(authorId))
                .Returns(BookData.Where(b =>
                    b.AuthorID == authorId).ToList());

            //inject
            var bookService =
                new BookService(mockedBookRepository.Object);
            var authorService =
                new AuthorService(mockedAuthorRepository.Object);
            var libraryService =
                new LibraryService(bookService, authorService);

            //act
            var result =
                libraryService.GetAllBooksCount(input, authorId);

            //Assert
            Assert.Equal(expectedCount, result);
        }

        [Fact]
        public void GetAllBooksByAuthorAfterDate_OK()
        {
            //setup
            var request = new GetAllBooksByAuthorRequest
            {
                AuthorId = 1,
                AfterDate = new DateTime(2000, 1, 1)
            };
            var expectedCount = 2;

            var mockedBookRepository =
                new Mock<IBookRepository>();
            var mockedAuthorRepository =
                new Mock<IAuthorRepository>();

            mockedBookRepository.Setup(
                    x =>
                        x.GetAllBooksByAuthor(request.AuthorId))
                .Returns(BookData
                    .Where(b => b.AuthorID == request.AuthorId)
                    .ToList());

            mockedAuthorRepository.Setup(
                    x =>
                        x.GetById(request.AuthorId))
                .Returns(AuthorData!
                    .FirstOrDefault(a =>
                        a.Id == request.AuthorId)!);

            //inject
            var bookService =
                new BookService(mockedBookRepository.Object);
            var authorService =
                new AuthorService(mockedAuthorRepository.Object);
            var service = new LibraryService(bookService, authorService);

            //Act
            var result =
                service.GetAllBooksByAuthorAfterDate(request);

            //Assert
            Assert.NotNull(result);
            Assert.Equal(expectedCount, result!.Books.Count);
            Assert.Equal(request.AuthorId, result.Author.Id);
        }

    }
}