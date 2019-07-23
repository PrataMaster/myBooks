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
        Task NavigateToSettings();
    }
}
