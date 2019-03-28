using Library.Models;
using System.Collections.Generic;

namespace Library.Repository.Interface
{
    public interface IBookRepository
    {
        List<Book> GetAvaliable(bool avaliable);
    }
}
