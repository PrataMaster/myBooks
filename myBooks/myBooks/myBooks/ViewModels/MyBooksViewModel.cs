using myBooks.Models;
using myBooks.ViewModels.Services;
using System;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace myBooks.ViewModels
{
    public class MyBooksViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        public ObservableCollection<Livro> MyBooks { get; set; }
        public ICommand NavigateToWishListCommand { get; set; }
        public ICommand NavigateToFavoritesCommand { get; set; }
        public ICommand NavigateToSettingCommand { get; set; }

        public MyBooksViewModel()
        {
            navigationService = DependencyService.Get<INavigationService>();
            NavigateToWishListCommand = new Command(NavigateToWishList);
            NavigateToFavoritesCommand = new Command(NavigateToFavorites);
            NavigateToSettingCommand = new Command(NavigateToSettings);
            MyBooks = new ObservableCollection<Livro>();
            for (int i = 0; i < 30; i++)
            {
                MyBooks.Add(new Livro { Title = "Fala Fiote", Genre = "Ah um genero ai", Year = Convert.ToInt16(1990 + i) });
            }
        }

        private void NavigateToWishList() => navigationService.NavigateToWishList();

        private void NavigateToFavorites() => navigationService.NavigateToFavorites();

        private void NavigateToSettings() => navigationService.NavigateToSettings();
    }
}
