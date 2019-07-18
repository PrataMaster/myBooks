using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace myBooks.ViewModels.Services
{
    public interface INavigationService
    {
        Task NavigateToSignIn();
        Task NavigateToSignUp();
        Task NavigateToMyBooks();
        Task NavigateToWishList();
        Task NavigateToFavorites();
    }
}
