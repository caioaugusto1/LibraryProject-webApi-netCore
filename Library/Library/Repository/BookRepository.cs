using Library.Models;
using Library.Repository.Interface;
using Microsoft.Extensions.Configuration;
using MongoDB.Driver;
using System.Collections.Generic;

namespace Library.Repository
{
    public class BookRepository : RepositoryBase<Book>, IBookRepository
    {
        public BookRepository(IConfiguration configuration) : base(configuration, "Books")
        {

        }

        public List<Book> GetAvaliable(bool avaliable)
        {
            return _mongoCollection.Find<Book>(x => x.Avaliable == avaliable).ToList();
        }
    }
}
