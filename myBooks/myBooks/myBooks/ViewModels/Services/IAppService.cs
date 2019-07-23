using myBooks.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace myBooks.ViewModels.Services
{
    public interface IAppService
    {
        #region BooksRequest
        //Get
        Task<List<Livro>> GetBooks();
        //GetById
        Task<Livro> GetBookById(int id);
        //Post
        Task PostBook(Usuario usuario, Livro livro);
        //Put
        Task PutBook();
        //Delete
        Task DeleteBook();
        #endregion
    }
}
