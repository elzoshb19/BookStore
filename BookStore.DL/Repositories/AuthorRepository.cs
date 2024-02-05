using BookStore.DL.Interfaces;
using BookStore.DL.MemoryDB;
using BookStore.Models.Models;

namespace BookStore.DL.Repositories
{
    public class AuthorRepository : IAuthorRepository
    {
        public List<Author> GetAll()
        {
            return InMemoryDB.AuthorData;
        }

        public Author? GetById(int id)
        {
            return InMemoryDB.AuthorData.FirstOrDefault(a => a.Id == id);
        }

        public void Add(Author author)
        {
            InMemoryDB.AuthorData.Add(author);
        }

        public void Delete(int id)
        {
            var author = GetById(id);

            if (author != null)
            {
                InMemoryDB.AuthorData.Remove(author);
            }
        }
        }
}
