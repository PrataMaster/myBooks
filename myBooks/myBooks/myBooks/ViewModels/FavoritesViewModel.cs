using myBooks.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace myBooks.ViewModels
{
    public class FavoritesViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        public ICommand NavigateToMyBooksCommand { get; set; }
        public ICommand NavigateToWishListCommand { get; set; }
        public FavoritesViewModel()
        {
            navigationService = DependencyService.Get<INavigationService>();
            NavigateToMyBooksCommand = new Command(NavigateToMyBooks);
            NavigateToWishListCommand = new Command(NavigateToWishList);

        }

        private void NavigateToMyBooks()
        {
            navigationService.NavigateToMyBooks();
        }

        private void NavigateToWishList()
        {
            navigationService.NavigateToWishList();
        }
    }
}
