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
    public class FavoritesViewModel : BaseViewModel
    {
        private readonly INavigationService navigationService;
        public ObservableCollection<Livro> Favorites { get; set; }
        public ICommand NavigateToMyBooksCommand { get; set; }
        public ICommand NavigateToWishListCommand { get; set; }
        public ICommand NavigateToSettingCommand { get; set; }

        public FavoritesViewModel()
        {
            navigationService = DependencyService.Get<INavigationService>();
            NavigateToMyBooksCommand = new Command(NavigateToMyBooks);
            NavigateToWishListCommand = new Command(NavigateToWishList);
            NavigateToSettingCommand = new Command(NavigateToSettings);
            Favorites = new ObservableCollection<Livro>();
            for (int i = 0; i < 30; i++)
            {
                Favorites.Add(new Livro { Title = "Achou q ia terminar o Tcc a tempo?", Genre = "Achou errado otario", Year = Convert.ToInt16(1990 + i) });
            }

        }

        private void NavigateToMyBooks() => navigationService.NavigateToMyBooks();

        private void NavigateToWishList() => navigationService.NavigateToWishList();

        private void NavigateToSettings() => navigationService.NavigateToSettings();
    }
}
