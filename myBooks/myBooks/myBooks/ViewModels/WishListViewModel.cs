using myBooks.Models;
using myBooks.ViewModels.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace myBooks.ViewModels
{
    public class WishListViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        public ICommand NavigateToMyBooksCommand { get; set; }
        public ICommand NavigateToFavoritesCommand { get; set; }

        public ObservableCollection<Livro> WishList { get; set; }

        public WishListViewModel()
        {
            navigationService = DependencyService.Get<INavigationService>();
            NavigateToMyBooksCommand = new Command(NavigateToMyBooks);
            NavigateToFavoritesCommand = new Command(NavigateToFavorites);
            WishList = new ObservableCollection<Livro>();

            for (int i = 0; i < 30; i++)
            {
                WishList.Add(new Livro { Title = "KKKKKK", Genre = "Sei lá", Year = Convert.ToInt16(1990 + i) });
            }

        }

        private void NavigateToMyBooks()
        {
            navigationService.NavigateToMyBooks();
        }

        private void NavigateToFavorites()
        {
            navigationService.NavigateToFavorites();
        }
    }
}
